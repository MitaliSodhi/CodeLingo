from BeautifulSoup import BeautifulSoup as bs
import urlparse
from urllib2 import urlopen
from urllib import urlretrieve
import os
import sys
import json
import re
import goslate

def scrape(url):
    soup = bs(urlopen(url))

    tmall_main_soup = soup.find('div', {'class': 'menu j_Menu'})
    gs = goslate.Goslate()
    tmall_categories = []
    lang_list = ['af', 'am', 'ar', 'be', 'bg', 'ca', 'cs', 'da', 'de', 'el', 'en-rGB', 'es', 'es-rUS', 'et', 'fa', 'fi', 'fr', 'hi', 'hr', 'hu', 'in', 'it', 'iw', 'ja', 'ko', 'lt', 'lv', 'ms', 'nb', 'nl', 'pl', 'pt', 'pt-rPT', 'ro', 'ru', 'sk', 'sl', 'sr', 'sv', 'sw', 'th', 'tl', 'tr', 'uk', 'vi', 'zh-rCN', 'zh-rTW', 'zu']

    for i in range(0,17):
        class_name = "item item"+str(i)+" j_MenuItem"

        single_category = {}

        category_soup = tmall_main_soup.find('li', {'class': class_name})
        single_category['category_name_original'] = category_soup.h3.text
        single_category['category_name_english'] = gs.translate(category_soup.h3.text, 'en')
        single_category['products'] = []

        items_soup = category_soup.findAll('p')

        for item in items_soup:
            link_soup = item.findAll('a')
            for link in link_soup:
                single_link = {}
                tr_name = ""
                single_link['product_name_original'] = link.text
                if link.text.lower() in lang_list:
                    tr_name = link.text + "."
                    single_link['product_name_english'] = gs.translate(tr_name, 'en')
                else:
                    single_link['product_name_english'] = gs.translate(link.text, 'en')
                single_link['product_url'] = link['href']
                single_category['products'].append(single_link)

        tmall_categories.append(single_category)

    print json.dumps(tmall_categories)

if __name__ == "__main__":
    url = sys.argv[1]
    scrape(url)
