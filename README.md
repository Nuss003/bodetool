BodeTool
========

BodeTool è un programma open source (scritto in C#) per tracciare grafici di Bode.

========

GUIDA ALL'USO DI BODE TOOL:

COMANDI

k lineare < 0 : Settarlo se il k ottenuto come risultato del limite per s -> 0 è negativo

K (dB) : Inserire il guadagno statico espresso in decibel

Poli : Inserire uno o più poli (in modulo). In caso di più poli separarli con il punto e virgola (es: 0; 3; 0,01). Specificare anche i poli nell'origine

Zeri : Come per i poli. Anche se ci sono zeri che in fase si comportano come poli inserirli lo stesso come zeri.

zeri/poli a p.r.positiva : inserire (con la stessa sintassi spiegata poco sopra) i poli e gli zeri a parte reale negativa

Se non ci sono poli o zeri lasciare il campo di testo vuoto (Vale anche per il campo zeri e il campo poli)

In caso si specifica un tipo di rete corretrice da applicare bisogna anche specificare M e Tau.

x min : Specificare la potenza di dieci da cui il grafico deve partire (es. 0,001)

Calcola : Disegna i grafici

Salva : Salva i grafici in due jpg diversi (uno per il modulo e uno per la fase) nella cartella del programma.

BUG NOTI:
- Purtroppo c'è una perdita di precisione per quei poli/zeri che si trovano tra uno di quegli spazi in cui è divisa la decade. Il polo/zero viene (in questo caso) arrotondato.

    Se si usa un M o un K decimale il programma potrebbe crashare, meglio usare valori interi.

    Un bode con uno zero ed un polo coincidenti ed entrambi a parte reale positiva non viene calcolato correttamente.
 
