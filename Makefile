
libarg = -recurse:src/lib/*
common = -recurse:src/common/*

output:
	make server
	make client
	echo "";echo "DONE!";date

server:
	mcs $(libarg) $(common) -recurse:src/server/* -out:toltserver.cil

client:
	mcs $(libarg) $(common) -recurse:src/client/* -out:toltclient.cil
