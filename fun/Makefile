# all: out.txt; cat $<

# out.txt: main.exe
# 	$(RUN) $< > $@

alpha.dll: alpha.cs
	mcs -target:library -out:$@ $<

main.exe: main.cs
	mcs main.cs
