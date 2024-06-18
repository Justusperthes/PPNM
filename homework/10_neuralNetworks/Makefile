CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
COMMON_CLASSES_DIR := ../common_classes
OTHER_DIR := ../9_minimisation
CSC = mcs
export MONO_PATH := $(COMMON_CLASSES_DIR):$(OTHER_DIR)
RUN = mono

all: out.txt; cat $<

out.txt: main.exe
	$(RUN) $< > $@

main.exe: main.cs ann.dll
	$(CSC) -reference:ann.dll $<

ann.dll: ann.cs  #; $(MKLIB)
	$(CSC) -target:library -out:$@ ann.cs

clean:
	$(RM) *.dll *.exe [Oo]ut*