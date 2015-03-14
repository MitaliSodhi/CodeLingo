#include <stdio.h>
#include <string.h>
#include <assert.h>
#include <ctype.h>

#include "cleanurl.h"

static void remove_trailing_stuff(char* out_url)
{
    int slen=strlen(out_url);
    char* p=out_url+slen-1;
    for(;p!=out_url;p--){
        char c=*p;
        if(c=='/'){
            return;
        }
        if(c=='#'||c=='?'||c==';'){
            *p=0;
        }
    }
}

static void remove_trailing_directory_index(char* out_url)
{
    int slen=strlen(out_url);
    static char* indexs[]={
        "/default.php",
        "/default.asp",
        "/default.aspx",
        "/defautl.html",
        "/defautl.htm",

        "/index.php",
        "/index.asp",
        "/index.aspx",
        "/index.html",
        "/index.htm",
    };

    static int lens[]={
        12,
        12,
        13,
        13,
        12,

        10,
        10,
        11,
        11,
        10,
    };

    /*remove directory index*/
    for(int j=0;j<sizeof(indexs)/sizeof(indexs[-1]);j++){
        char* s=indexs[j];
        int l=lens[j];
        if(slen>l && strncmp(s,out_url+slen-l,l)==0){
            out_url[slen-l]=0;
            return;
        }
    }
    return;
}

/**
 * @return boolean value
 */
static int invalidate_prev_seg(int* arr,int i){
    assert(i>=0);
    for(;i>=0;i--){
        if(arr[i]){
            arr[i]=0;
            return 1;
        }
    }
    return 0;
}

/**
 * @return boolean value
 */
static int output_valid_segments(char* out_url,const char* s, const char* e){
    int cnt=1; /*1024 is more than enough to hold all the segments*/
    const char* segs[1024]={0}; /* segment of sub path */
    int seg_len[1024]={0}; /*if seg_len[i]==0, segs[i] is ignored */
    char* buf;

    segs[0]=s-1; /* dummy head */
    for(const char* p=s;p<e;p++){
        if(*p=='/'){
            segs[cnt]=p;
            cnt++;
        }
    }
    segs[cnt]=e;

    /* second scan, here is what stored in segs[]
       address:  0     6     12
       string:   /hello/world/bye
       so the length of each segment is segs[i+1]-segs[i]-1
       the string starts from seg[i]+1
       here is the algorithm
       if the string length equals 0, the seg_len[i]=false
       if the current segment is "../", toggle off the previous valid segment
       if the current segment is "./", toggle off the current segment
    */
    for(int i=0;i<cnt;i++){
        int len=segs[i+1]-segs[i]-1;
        assert(len>=0);
        switch(len){
            case 0: /* "//" */
                seg_len[i]=0;
                break;
            case 1: /* "./" */
                if(*(segs[i]+1)=='.'){
                    seg_len[i]=0;
                }
                else{
                    seg_len[i]=len;
                }
                break;
            case 2: /* "/../" */
                if(strncmp(segs[i]+1,"..",2)==0){
                    /* remove "../" */
                    seg_len[i]=0;
                    /* and remove parent directory */
                    if(!invalidate_prev_seg(seg_len,i-1)){
                        return 0;
                    }
                }
                else{
                    seg_len[i]=len;
                }
                break;
            default:
                seg_len[i]=len;
        }
    }

    /* third scan, output all the segments */
    buf=out_url; /* buf is for appending string in out_url */
    for(int i=0;i<cnt;i++){
        /* dump segments no */
        if(!seg_len[i]){
            continue;
        }
        strncpy(buf,segs[i]+1,seg_len[i]);
        buf+=seg_len[i];
        if(i!=cnt-1){
            *buf='/';
            buf++;
        }
    }
    *buf=0; /* close the string */

    return 1;
}

/**
 * @return boolean value
 */
static int is_valid_host(const char*s, int host_len)
{
    const char* e=s+host_len;
    /* scheme = alpha digit / "+" / "-" / "." ) */
    for(;s!=e;s++){
        if(! (isalnum(*s) || *s=='+' || *s=='-' || *s=='.') ) {
            return 0;
        }
    }
    return 1;
}
/**
 * @return pointer to sub path of url, without leading '/'
 * @param[out] num_of_chars_hostnam 0, invalid url; >0, the length of host
 */
static const char* extract_host(const char* s, const char* e,int* num_of_chars_hostname)
{
    const char*p=s;
    *num_of_chars_hostname=0;
    for(;p<e;p++){
        if(*p==':'){
            *num_of_chars_hostname=p-s;
            /* skip the port number */
            p++;
            for(;p<e && (*p!='/');p++){
                if(!isdigit(*p)){
                    *num_of_chars_hostname=0;
                    return e;
                }
            }
            return p+1;
        }
        else if(*p=='/'){
            *num_of_chars_hostname=p-s;
            return p+1;
        }
    }
    *num_of_chars_hostname=e-s;
    return e;
}

/**
 * @param[out] buf
 * @param[in] src
 */
static void urldecode(char* buf,const char* src,int slen) {
    char tmp[4]={0};
    char ch;
    int i, ii,buf_cnt=0;
    for (i=0; i<slen; i++) {
        if (((int)src[i])==37) {
            tmp[0]=src[i+1];
            tmp[1]=src[i+2];
            sscanf(tmp, "%x", &ii);
            ch=(char)ii;
            if( (ch>=65&&ch<=90) || (ch>=48&&ch<=57) || (ch>=97&&ch<=122) || ch==45 || ch==46 || ch==95 || ch==126 ){
                buf[buf_cnt++]=ch;
                i=i+2;
            }
            else{
                buf[buf_cnt++]=src[i];
            }
        } else {
            buf[buf_cnt++]=src[i];
        }
    }
    buf[buf_cnt]=0;
}

/**
 * @see RFC 3986 for URL parsing
 * @return 0, succeed; other, error number
 */
int clean_url(char * buf, const char* in,int in_strlen) {
    /* 2048 is moren than enough to hold an url */
    char orig_url[2048]={0};
    char* s=orig_url;
    const char* e=s+in_strlen;
    const char* sub_path;
    int host_len=0,err=0,slen;

    /* to lower case */
    for(int i=0;i<in_strlen;i++){
        orig_url[i]=tolower(in[i]);
    }

    /* remove http(s) */
    if(strncmp(s,"http",4)!=0){
        //valid url should start with 'http'
        return err=1;
    }
    s+=4;
    if(s>=e){ return err=2; }

    /* https? */
    if(*s=='s'){
        s++;
    }
    if(s>=e){ return err=3; }

    /* remove "://: */
    if(strncmp(s,"://",3)!=0){
        return err=4;
    }
    s+=3;
    if(s>=e){ return err=5; }

    /* remove "www." */
    while(strncmp(s,"www.",4)==0){
        s+=4;
        if(s>=e){ return err=6; }
    }


    /*
      clean the authority?
      authority = [ userinfo "@" ] host [ ":" port
      I only clean the port
    */
    sub_path=extract_host(s,e,&host_len);
    if(!host_len){ return err=7; }

    if(!is_valid_host(s,host_len)){
        return err=8;
    }
    strncpy(buf,s,host_len);
    *(buf+host_len)=0;

    if(sub_path<e){
        buf[host_len]='/';
        /* now we handle sub_path, divide the subpath into different segments
           and re-calculate the segment according to the the "../" and "."
        */
        if(!output_valid_segments(buf+host_len+1,sub_path,e)){
            return err=9;
        }
    }

    /* fragment,semi-query-string,question-mark */
    remove_trailing_stuff(buf);

    /* remove directory index */
    remove_trailing_directory_index(buf);

    slen=strlen(buf);

    /* remove trailing '/' */
    if(buf[slen-1]=='/'){
        buf[slen-1]=0;
        slen--;
    }

    urldecode(buf,buf,slen);
    return 0;
}
