import glob
import nltk
import csv
import collections

c_file = open('keyword_c.txt').readlines()
java_file = open('keyword_java.txt').readlines()
python_file = open('keyword_python.txt').readlines()
cpp_file = open('keyword_cpp.txt').readlines()
ruby_file = open('keyword_ruby.txt').readlines()
html_file = open('keyword_html.txt').readlines()
javascript_file = open('keyword_javascript.txt').readlines()
objective_c_file = open('keyword_objective_c.txt').readlines()
cs_file = open('keyword_cs.txt').readlines()
perl_file = open('keyword_perl.txt').readlines()

keywords = []

for keyword in c_file:
    if keyword.strip() not in keywords:
        keywords.append(keyword.strip())

for keyword in java_file:
    if keyword.strip() not in keywords:
        keywords.append(keyword.strip())

for keyword in python_file:
    if keyword.strip() not in keywords:
        keywords.append(keyword.strip())

for keyword in cpp_file:
    if keyword.strip() not in keywords:
        keywords.append(keyword.strip())

for keyword in ruby_file:
    if keyword.strip() not in keywords:
        keywords.append(keyword.strip())

for keyword in html_file:
    if keyword.strip() not in keywords:
        keywords.append(keyword.strip())

for keyword in javascript_file:
    if keyword.strip() not in keywords:
        keywords.append(keyword.strip())

for keyword in objective_c_file:
    if keyword.strip() not in keywords:
        keywords.append(keyword.strip())

for keyword in cs_file:
    if keyword.strip() not in keywords:
        keywords.append(keyword.strip())

for keyword in perl_file:
    if keyword.strip() not in keywords:
        keywords.append(keyword.strip())

keywords_dummy = []
for word in keywords:
    keywords_dummy.append(word)
keywords_dummy.append("language")

csvfile = open('dataset_binary.csv', 'wb')
rowwriter = csv.writer(csvfile, delimiter=',')
rowwriter.writerow(keywords_dummy)

# i = 1
# for code_file in glob.glob("../Test_Data/*.*"):
#     source_file = open(code_file).read()
#     keyword_list = []
#     token_list = nltk.word_tokenize(source_file)
#     counter=collections.Counter(token_list)
#     for each_token in keywords:
#         if each_token in token_list:
#             keyword_list.append(counter[each_token])
#         else:
#             keyword_list.append(0)
#     keyword_list.append(code_file.split('.')[-1])

#     rowwriter = csv.writer(csvfile, delimiter=',')
#     rowwriter.writerow(keyword_list)
#     print "Test Files processed", i
#     i += 1

i = 1
for code_file in glob.glob("c/*.*"):
    source_file = open(code_file).read()
    keyword_list = []
    token_list = nltk.word_tokenize(source_file)
    counter=collections.Counter(token_list)
    for each_token in keywords:
        if each_token in token_list:
            keyword_list.append(1)
        else:
            keyword_list.append(0)
    keyword_list.append("c")

    rowwriter = csv.writer(csvfile, delimiter=',')
    rowwriter.writerow(keyword_list)
    print "C Files processed", i
    i += 1

i = 1
for code_file in glob.glob("java/*.*"):
    source_file = open(code_file).read()
    keyword_list = []
    token_list = nltk.word_tokenize(source_file)
    counter=collections.Counter(token_list)
    for each_token in keywords:
        if each_token in token_list:
            keyword_list.append(1)
        else:
            keyword_list.append(0)
    keyword_list.append("java")

    rowwriter = csv.writer(csvfile, delimiter=',')
    rowwriter.writerow(keyword_list)
    print "Java Files processed", i
    i += 1

i = 1
for code_file in glob.glob("python/*.*"):
    source_file = open(code_file).read()
    keyword_list = []
    token_list = nltk.word_tokenize(source_file)
    counter=collections.Counter(token_list)
    for each_token in keywords:
        if each_token in token_list:
            keyword_list.append(1)
        else:
            keyword_list.append(0)
    keyword_list.append("python")

    rowwriter = csv.writer(csvfile, delimiter=',')
    rowwriter.writerow(keyword_list)
    print "Python Files processed", i
    i += 1

i = 1
for code_file in glob.glob("cpp/*.*"):
    source_file = open(code_file).read()
    keyword_list = []
    token_list = nltk.word_tokenize(source_file)
    counter=collections.Counter(token_list)
    for each_token in keywords:
        if each_token in token_list:
            keyword_list.append(1)
        else:
            keyword_list.append(0)
    keyword_list.append("cpp")

    rowwriter = csv.writer(csvfile, delimiter=',')
    rowwriter.writerow(keyword_list)
    print "CPP Files processed", i
    i += 1

i = 1
for code_file in glob.glob("ruby/*.*"):
    source_file = open(code_file).read()
    keyword_list = []
    token_list = nltk.word_tokenize(source_file)
    counter=collections.Counter(token_list)
    for each_token in keywords:
        if each_token in token_list:
            keyword_list.append(1)
        else:
            keyword_list.append(0)
    keyword_list.append("ruby")

    rowwriter = csv.writer(csvfile, delimiter=',')
    rowwriter.writerow(keyword_list)
    print "Ruby Files processed", i
    i += 1

i = 1
for code_file in glob.glob("html/*.*"):
    source_file = open(code_file).read()
    keyword_list = []
    token_list = nltk.word_tokenize(source_file)
    counter=collections.Counter(token_list)
    for each_token in keywords:
        if each_token in token_list:
            keyword_list.append(1)
        else:
            keyword_list.append(0)
    keyword_list.append("html")

    rowwriter = csv.writer(csvfile, delimiter=',')
    rowwriter.writerow(keyword_list)
    print "HTML Files processed", i
    i += 1

i = 1
for code_file in glob.glob("javascript/*.*"):
    source_file = open(code_file).read()
    keyword_list = []
    token_list = nltk.word_tokenize(source_file)
    counter=collections.Counter(token_list)
    for each_token in keywords:
        if each_token in token_list:
            keyword_list.append(1)
        else:
            keyword_list.append(0)
    keyword_list.append("javascript")

    rowwriter = csv.writer(csvfile, delimiter=',')
    rowwriter.writerow(keyword_list)
    print "Javascript Files processed", i
    i += 1

i = 1
for code_file in glob.glob("objective_c/*.*"):
    source_file = open(code_file).read()
    keyword_list = []
    token_list = nltk.word_tokenize(source_file)
    counter=collections.Counter(token_list)
    for each_token in keywords:
        if each_token in token_list:
            keyword_list.append(1)
        else:
            keyword_list.append(0)
    keyword_list.append("objective_c")

    rowwriter = csv.writer(csvfile, delimiter=',')
    rowwriter.writerow(keyword_list)
    print "Objective C Files processed", i
    i += 1

i = 1
for code_file in glob.glob("cs/*.*"):
    source_file = open(code_file).read()
    keyword_list = []
    token_list = nltk.word_tokenize(source_file)
    counter=collections.Counter(token_list)
    for each_token in keywords:
        if each_token in token_list:
            keyword_list.append(1)
        else:
            keyword_list.append(0)
    keyword_list.append("cs")

    rowwriter = csv.writer(csvfile, delimiter=',')
    rowwriter.writerow(keyword_list)
    print "C# Files processed", i
    i += 1

i = 1
for code_file in glob.glob("perl/*.*"):
    source_file = open(code_file).read()
    keyword_list = []
    token_list = nltk.word_tokenize(source_file)
    counter=collections.Counter(token_list)
    for each_token in keywords:
        if each_token in token_list:
            keyword_list.append(1)
        else:
            keyword_list.append(0)
    keyword_list.append("perl")

    rowwriter = csv.writer(csvfile, delimiter=',')
    rowwriter.writerow(keyword_list)
    print "Perl Files processed", i
    i += 1
