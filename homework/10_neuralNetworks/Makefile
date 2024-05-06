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

main.exe: main.cs Matrix.dll QRGS.dll Minimisation.dll ann.dll ; $(MKEXE)

Matrix.dll: $(COMMON_CLASSES_DIR)/vector.cs $(COMMON_CLASSES_DIR)/Matrix.cs ; $(MKLIB)

QRGS.dll: $(COMMON_CLASSES_DIR)/QRGS.cs $(COMMON_CLASSES_DIR)/Matrix.dll ; $(MKLIB)

Minimisation.dll: $(OTHER_DIR)/Minimisation.cs \
		$(COMMON_CLASSES_DIR)/Matrix.dll \
		$(COMMON_CLASSES_DIR)/QRGS.dll \
		; $(MKLIB);

ann.dll: ann.cs Matrix.dll ; $(MKLIB)

clean:
	$(RM) *.dll *.exe [Oo]ut*

test:
	ls $(OTHER_DIR)
