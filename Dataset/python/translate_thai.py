import goslate
import urllib2
import json
import collections

#json_file = urllib2.urlopen('http://180.151.97.90/priceweave/PriceWeave_THAI/select?q=source:Lazada&wt=json&start=0&rows=31066').read()

json_file = open('lazada.json')

json_data = json.load(json_file)

gs = goslate.Goslate()
count = 0

translated_data = []

translated_data.append({'count': len(json_data['response']['docs'])})

for each_product in json_data['response']['docs']:
    product_details = collections.OrderedDict()

    product_details['category'] = each_product.get('category', '')

    try:
        product_details['category_translated'] = gs.translate(product_details['category'], 'en')
    except (urllib2.HTTPError, urllib2.URLError):
        product_details['category_translated'] = ""

    product_details['status'] = each_product.get('status', '')
    product_details['crawl_date'] = each_product.get('crawl_date', '')
    product_details['crawl_time'] = int(each_product.get('crawl_time', ''))
    product_details['subcategory'] = each_product.get('subcategory', '')

    try:
        product_details['subcategory_translated'] = gs.translate(product_details['subcategory'], 'en')
    except (urllib2.HTTPError, urllib2.URLError):
        product_details['subcategory_translated'] = ""
    product_details['title'] = each_product['title']

    try:
        title = ""
        for word in each_product['title'].split():
            translated_word = gs.translate(word.strip(), 'en', 'th')
            if translated_word[-1] == '.':
                translated_word = translated_word[:-1]
            title += translated_word + ' '
        product_details['title_translated'] = title.strip()
    except (urllib2.HTTPError, urllib2.URLError):
        product_details['title_translated'] = ""

    product_details['url'] = each_product.get('url', '')
    product_details['brand'] = each_product.get('brand', '')
    product_details['mrp'] = each_product.get('mrp', '')
    product_details['urlh'] = each_product.get('urlh', '')
    product_details['tracked'] = each_product.get('tracked', '')
    product_details['source'] = each_product.get('source', '')
    product_details['cashback'] = each_product.get('cashback', '')
    product_details['title_t'] = each_product.get('title_t', '')
    product_details['added_today_i'] = each_product.get('added_today_i', '')
    product_details['discount'] = each_product.get('discount', '')
    product_details['available_price'] = each_product.get('available_price', '')
    product_details['thumbnail'] = each_product.get('thumbnail', '')
    product_details['price_change'] = each_product.get('price_change', '')
    product_details['stock'] = each_product.get('stock', '')
    product_details['_version_'] = each_product.get('_version_', '')

    translated_data.append(product_details)

    count += 1
    print count, "rows written"

write_file = open('lazada_output.json', 'w')
write_file.write(json.dumps(translated_data, indent=4))


