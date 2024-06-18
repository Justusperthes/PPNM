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

main.exe: main.cs Matrix.dll QRGS.dll Roots.dll 
	$(CSC) -reference:Matrix.dll -reference:QRGS.dll -reference:Roots.dll $<

Matrix.dll : $(COMMON_CLASSES_DIR)/vector.cs $(COMMON_CLASSES_DIR)/Matrix.cs
	$(CSC) -target:library -out:$@ $^

QRGS.dll: $(COMMON_CLASSES_DIR)/QRGS.cs Matrix.dll ; $(MKLIB)

Roots.dll : Roots.cs Matrix.dll QRGS.dll #; $(MKLIB)
	$(CSC) -reference:Matrix.dll -reference:QRGS.dll -target:library -out:$@ Roots.cs

clean:
	$(RM) *.dll *.exe [Oo]ut*
