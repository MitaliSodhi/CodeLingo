from BeautifulSoup import BeautifulSoup as bs
#import urlparse
from urllib2 import urlopen
#from urllib import urlretrieve
#import os
import sys
import json
#import re
import Color_Palette as CP

def scrape(url):
    soup = bs(urlopen(url))

    pin_main = {}
    pin_main['items'] = []

    main_soup = soup.findAll('div', {'class': 'pinWrapper'})

    for each_pin in main_soup:
        single_item = {}
        single_item['tags'] = []

        holder_soup = each_pin.findAll('div', {'class': 'pinHolder'})

        for item in holder_soup:
            for image in item.findAll('img'):
                single_item['image_url'] = "%(src)s" % image

        single_item['image_palette'] = CP.colorz(single_item['image_url'])

        meta_soup = each_pin.find('div', {'class': 'pinMeta '})

        for pintags in meta_soup.findAll('a', {'class': 'pintag'}):
            if pintags.string.strip()[0] == '#':
                single_item['tags'].append(pintags.string.strip())

        social_meta_soup = each_pin.find('div', {'class': 'pinSocialMeta'})

        if social_meta_soup.find('a', {'class': 'socialItem'}):
            for item in social_meta_soup.find('a', {'class': 'socialItem'}):
                single_item['repins'] = item.string.strip()[0]

        if social_meta_soup.find('a', {'class': 'socialItem likes'}):
            for item in social_meta_soup.find('a', {'class': 'socialItem likes'}):
                single_item['likes'] = item.string.strip().split()[0]

        pin_main['items'].append(single_item)

        #print single_item

    print json.dumps(pin_main)

if __name__ == "__main__":
    url = sys.argv[1]
    scrape(url)
