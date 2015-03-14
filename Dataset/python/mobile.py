from BeautifulSoup import BeautifulSoup as bs
import urlparse
from urllib2 import urlopen
from urllib import urlretrieve
import os
import sys
import json
import re
import goslate
import collections
import datetime

def scrape(url, count, all_items):
    soup = bs(urlopen(url))

    product_soup = soup.findAll('div', {'class': 'product'})

    gs = goslate.Goslate()

    for each_product in product_soup:
        now = datetime.datetime.now()

        single_item = collections.OrderedDict()
        single_item['category'] = 'cellphones'
        single_item['crawl_date'] = str(now.year)+str(now.month)+str(now.day)
        single_item['crawl_time'] = now.strftime("%Y%m%d%H%M%s")[:-8]
        single_item['title_original'] = each_product.find('p', {'class': 'productTitle'}).text
        single_item['title_english'] = gs.translate(single_item['title_original'], 'en')
        single_item['url'] = "http:"+each_product.find('p', {'class': 'productTitle'}).a['href']
        single_item['thumbnail'] = each_product.find('img')['data-ks-lazyload']
        single_item['price'] = each_product.find('em').text.replace('&yen; ', '').strip()
        single_item['brand'] = single_item['title_english'].split('/')[0].strip()
        single_item['status_original'] = each_product.find('p', {'class': 'productStatus'}).text
        single_item['status_english'] = gs.translate(single_item['status_original'], 'en')
        single_item['item_source'] = 'tmall'
        single_item['main_seller_original'] = each_product.find('a', {'class': 'productShop-name'}).text
        single_item['main_seller_english'] = gs.translate(single_item['main_seller_original'], 'en')
        single_item['item_other_sellers'] = []

        extra_soup = each_product.find('div', {'class': 'productExtraShops'})

        if extra_soup:
            extra_shop_soup = extra_soup.findAll('a')

        for each_shop in extra_shop_soup:
            other_shop = {}
            other_shop['seller_name_original'] = each_shop.find('span', {'class': 'pES-bd-seller'}).text
            other_shop['seller_name_english'] = gs.translate(other_shop['seller_name_original'], 'en')
            other_shop['seller_price'] = each_shop.find('span', {'class': 'pES-bd-price'}).text.split(';')[1]
            single_item['item_other_sellers'].append(other_shop)
            other_shop['seller_url'] = "http:"+each_shop['href']

        all_items.append(single_item)

        count += 1
        print count

    page_soup = soup.find('p', {'class': 'ui-page-s'})
    if int(soup.find('b', {'class': 'ui-page-s-len'}).text.split('/')[0]) != 20:
            for all_links in page_soup.findAll('a'):
                if all_links['class'] == 'ui-page-s-next':
                    scrape('http://list.tmall.com/search_product.htm'+all_links['href'], count, all_items)

    final_content = json.dumps(all_items)
    dump_file = open('mobile.json', 'w')
    dump_file.write(final_content)

if __name__ == "__main__":
    url = sys.argv[1]
    all_items = []
    scrape(url, 0, all_items)