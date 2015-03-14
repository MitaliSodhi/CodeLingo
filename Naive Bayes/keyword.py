# import re

# test_file = open('ins.c').read()
# keyword_file = open('keyword_c.txt').readlines()

# c_keyword = {}

# for keyword in keyword_file:
# 	if keyword in c_keyword:
# 		c_keyword[keyword.strip()] += 1
# 	else:
# 		c_keyword[keyword.strip()] = 1

# test_file = re.sub('[^A-Za-z]+', ' ', test_file)
# words = test_file.split()

# for word in words:
# 	if word in c_keyword:
# 		print word


import math
import re
import glob
import sys

#-------------------TRAINING CLASSIFIER---------------------#

class PLI():

	def __init__(self):
		self.data = {}
		self.totals = {}

		c_keyword = open('keyword_c.txt').readlines()
		java_keyword = open('keyword_java.txt').readlines()
		python_keyword = open('keyword_python.txt').readlines()

		self.keyword_list = {}
		self.keyword_list['c'] = {}
		self.keyword_list['java'] = {}
		self.keyword_list['python'] = {}

		for keyword in c_keyword:
			if keyword in self.keyword_list['c']:
				self.keyword_list['c'][keyword.strip()] += 1
			else:
				self.keyword_list['c'][keyword.strip()] = 1

		for keyword in java_keyword:
			if keyword in self.keyword_list['java']:
				self.keyword_list['java'][keyword.strip()] += 1
			else:
				self.keyword_list['java'][keyword.strip()] = 1

		for keyword in python_keyword:
			if keyword in self.keyword_list['python']:
				self.keyword_list['python'][keyword.strip()] += 1
			else:
				self.keyword_list['python'][keyword.strip()] = 1

	def words(self, code):
		code = re.sub('[^A-Za-z]+', ' ', code)
		word_list = code.split()
		return filter(bool, word_list)

	def train(self, code, lang):
		self.data[lang] = {}
		for word in self.words(code):
			if word in self.keyword_list[lang]:
				if word in self.data[lang]:
					self.data[lang][word] += 1
				else:
					self.data[lang][word] = 1
				if word in self.totals:
					self.totals[word] += 1
				else:
					self.totals[word] = 1

	def prob(self, words, lang):
		res = 0.0
		for word in words:
			try:
				res = res + math.log(self.totals[word]/self.data[lang][word])
			except(KeyError):
				continue
		return res

	def classify(self, code):
		lang_prob = {}
		words = self.words(code)
		for lang in self.data.iterkeys():
			prob = self.prob(words, lang)
			lang_prob[prob] = lang

		for something in lang_prob.keys():
			print something, lang_prob[something]
        #return lang_prob[min(lang_prob.keys())]

#-------------------TESTING CLASSIFIER----------------#

classifier = PLI()

for p in glob.glob("c/*.*"):
	classifier.train(open(p).read(), "c")
#for q in glob.glob("cpp/*.*"):
#    classifier.train(open(q).read(), "c++")
for r in glob.glob("java/*.*"):
	classifier.train(open(r).read(), "java")
	for s in glob.glob("python/*.*"):
		classifier.train(open(s).read(), "python")

#for t in glob.glob("python/*.*"):
#   print classifier.classify(open(t).read())
classifier.classify(open(sys.argv[1]).read())