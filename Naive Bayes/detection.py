import math
import re
import glob
import sys

#-------------------TRAINING CLASSIFIER---------------------#

class PLI():

    def __init__(self):
        self.data = {}
        self.totals = {}

    def words(self, code):
        word_list = code.split()
        return filter(bool, word_list)

    def train(self, code, lang):
        self.data[lang] = {}
        for word in self.words(code):
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

        # for something in lang_prob.keys():
        #     print something, lang_prob[something]
        return lang_prob[max(lang_prob.keys())]

#-------------------TESTING CLASSIFIER----------------#

classifier = PLI()

for p in glob.glob("../CSV_Generation/c/*.*"):
    classifier.train(open(p).read(), "c")
for q in glob.glob("../CSV_Generation/cpp/*.*"):
    classifier.train(open(q).read(), "cpp")
for r in glob.glob("../CSV_Generation/java/*.*"):
    classifier.train(open(r).read(), "java")
for s in glob.glob("../CSV_Generation/python/*.*"):
    classifier.train(open(s).read(), "python")
for t in glob.glob("../CSV_Generation/ruby/*.*"):
    classifier.train(open(t).read(), "ruby")
for u in glob.glob("../CSV_Generation/html/*.*"):
    classifier.train(open(u).read(), "html")
for v in glob.glob("../CSV_Generation/cs/*.*"):
    classifier.train(open(v).read(), "cs")
for w in glob.glob("../CSV_Generation/perl/*.*"):
    classifier.train(open(w).read(), "perl")
for x in glob.glob("../CSV_Generation/javascript/*.*"):
    classifier.train(open(x).read(), "javascript")
for y in glob.glob("../CSV_Generation/objective_c/*.*"):
    classifier.train(open(y).read(), "objective_c")

for z in glob.glob("Test_Data/*.*"):
   print z.split('.')[-1], classifier.classify(open(z).read())
#classifier.classify(open(sys.argv[1]).read())
