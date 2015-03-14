import glob
import detection

classifier = detection.PLI()

for p in glob.glob("c/*.*"):
	classifier.train(open(p).read(), "c")
for q in glob.glob("cpp/*.*"):
	classifier.train(open(q).read(), "c++")
for r in glob.glob("java/*.*"):
	classifier.train(open(r).read(), "java")
for s in glob.glob("python/*.*"):
	classifier.train(open(s).read(), "python")

#for t in glob.glob("c/*.*"):
#	print classifier.classify(open(t).read())
print classifier.classify(open("PingService.c").read())
