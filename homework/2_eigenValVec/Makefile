CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
COMMON_CLASSES_DIR := ../common_classes
CSC = mcs
export MONO_PATH := $(COMMON_CLASSES_DIR)
RUN = mono

all: out.txt; cat $<

out.txt: main.exe
	$(RUN) $< > $@

out2: test.exe
	$(RUN) $< > $@

main.exe: main.cs Matrix.dll Jacobi.dll
	$(CSC) -reference:Matrix.dll -reference:Jacobi.dll $<

Matrix.dll: $(COMMON_CLASSES_DIR)/vector.cs $(COMMON_CLASSES_DIR)/Matrix.cs ; $(MKLIB)
	mcs -target:library -out:$@ $^

Jacobi.dll : Jacob.cs Matrix.dll #; $(MKLIB)
	$(CSC) -reference:Matrix.dll -target:library -out:$@ Jacob.cs

clean:
	$(RM) *.dll *.exe [Oo]ut*
