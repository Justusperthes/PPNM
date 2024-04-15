CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
CSC = mcs
RUN = mono

# concatinates (cat) the content of out.txt into a message on
# the bash, I think
all: out.txt; cat $<

# out.txt should be created from the output of running main.exe,
# the command specifies: run mono on the first dependency (main.exe)
out.txt: main.exe
	$(RUN) $< > $@

out2: test.exe
	$(RUN) $< > $@

# main.cs is compiled into main.exe while matrix.dll is 
# referenced (the second dependency in the list: $(word 2,$^))
main.exe: main.cs vector.dll mc.dll
	$(CSC) -reference:vector.dll -reference:mc.dll $<

vector.dll : vector.cs #; $(MKLIB)
	$(CSC) -target:library -out:$@ vector.cs

mc.dll : mc.cs vector.dll #; $(MKLIB)
	$(CSC) -reference:vector.dll -target:library -out:$@ mc.cs

test.exe : test.cs
	$(CSC) $<

# removes .dll and .exe and out. files
clean:
	$(RM) *.dll *.exe [Oo]ut*
