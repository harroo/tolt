
libarg = -recurse:src/lib/*

output:
	make server

server:
	mcs $(libarg) -recurse:src/server/* -out:toltserver.cil
