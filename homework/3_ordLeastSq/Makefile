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
main.exe: main.cs matrix.dll ordLeastSq.dll QRGS.dll
	$(CSC) -reference:matrix.dll -reference:ordLeastSq.dll -reference:QRGS.dll $<

# matrix.dll is build from vector.cs and matrix.cs,
# -target:library means that output should be DLL rather than exe
# the output file name is matrix.dll, bc $@ is the target.
matrix.dll : vector.cs matrix.cs
	$(CSC) -target:library -out:$@ $^

QRGS.dll : QRGS.cs matrix.dll #; $(MKLIB)
	$(CSC) -reference:matrix.dll -target:library -out:$@ QRGS.cs

ordLeastSq.dll : ordLeastSq.cs matrix.dll QRGS.dll #; $(MKLIB)
	$(CSC) -reference:matrix.dll -reference:QRGS.dll -target:library -out:$@ ordLeastSq.cs

test.exe : test.cs
	$(CSC) $<

# removes .dll and .exe and out. files
# but where is (RM) actually defined?
clean:
	$(RM) *.dll *.exe [Oo]ut*
