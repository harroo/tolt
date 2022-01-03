
libarg = -recurse:src/lib/*

output:
	make server
	make client

server:
	mcs $(libarg) -recurse:src/server/* -out:toltserver.cil

client:
	mcs $(libarg) -recurse:src/client/* -out:toltclient.cil
