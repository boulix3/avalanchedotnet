#!/bin/bash
version='v1.2.0'
filename='avalanchego-'$version'/avalanchego'
echo $filename
if test -f $filename;then
	echo 'found '$filename
else
	wget https://github.com/ava-labs/avalanchego/releases/download/v1.2.0/avalanchego-linux-amd64-v1.2.0.tar.gz
	tar xvf avalanchego-linux-amd64-v1.2.0.tar.gz
fi
"$filename --network-id=fuji"
echo 'the end'

