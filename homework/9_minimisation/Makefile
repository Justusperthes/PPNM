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

main.exe: main.cs Matrix.dll QRGS.dll Minimisation.dll
	$(CSC) main.cs -reference:$(COMMON_CLASSES_DIR)/Matrix.dll -reference:$(COMMON_CLASSES_DIR)/QRGS.dll -reference:Minimisation.dll

Matrix.dll: $(COMMON_CLASSES_DIR)/vector.cs $(COMMON_CLASSES_DIR)/Matrix.cs ; $(MKLIB)
	mcs -target:library -out:$@ $^

QRGS.dll: $(COMMON_CLASSES_DIR)/QRGS.cs Matrix.dll
	$(CSC) -reference:$(COMMON_CLASSES_DIR)/Matrix.dll -target:library -out:$@ $(COMMON_CLASSES_DIR)/QRGS.cs

Minimisation.dll: Minimisation.cs Matrix.dll QRGS.dll
	$(CSC) -r:$(COMMON_CLASSES_DIR)/Matrix.dll -reference:$(COMMON_CLASSES_DIR)/QRGS.dll Minimisation.cs -target:library -out:$@

clean:
	$(RM) *.dll *.exe [Oo]ut*