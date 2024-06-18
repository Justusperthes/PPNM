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

main.exe: main.cs ann.dll Matrix.dll QRGS.dll Minimisation.dll
	$(CSC) -reference:ann.dll -reference:Matrix.dll -reference:QRGS.dll -reference:Minimisation.dll $<

Matrix.dll: $(COMMON_CLASSES_DIR)/vector.cs $(COMMON_CLASSES_DIR)/Matrix.cs ; $(MKLIB)
	mcs -target:library -out:$@ $^

Minimisation.dll: $(OTHER_DIR)/Minimisation.cs Matrix.dll QRGS.dll
	$(CSC) -r:Matrix.dll -reference:QRGS.dll $(OTHER_DIR)/Minimisation.cs -target:library -out:$@

QRGS.dll: $(COMMON_CLASSES_DIR)/QRGS.cs Matrix.dll
	$(CSC) -reference:Matrix.dll -target:library -out:$@ $(COMMON_CLASSES_DIR)/QRGS.cs

ann.dll: ann.cs Matrix.dll QRGS.dll Minimisation.dll
	$(CSC) -reference:Matrix.dll -reference:Minimisation.dll -target:library -out:$@ ann.cs

clean:
	$(RM) *.dll *.exe [Oo]ut*