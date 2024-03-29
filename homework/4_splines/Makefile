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
main.exe: main.cs lsplines.dll qsplines.dll
	$(CSC) -reference:lsplines.dll -reference:qsplines.dll $<

# matrix.dll is build from vector.cs and matrix.cs,
# -target:library means that output should be DLL rather than exe
# the output file name is matrix.dll, bc $@ is the target.

lsplines.dll : lsplines.cs #; $(MKLIB)
	$(CSC) -target:library -out:$@ lsplines.cs

qsplines.dll : qsplines.cs #; $(MKLIB)
	$(CSC) -target:library -out:$@ qsplines.cs

test.exe : test.cs
	$(CSC) $<

# removes .dll and .exe and out. files
# but where is (RM) actually defined?
clean:
	$(RM) *.dll *.exe [Oo]ut*
