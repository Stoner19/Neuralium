#!/bin/bash

mkdir deps
mkdir local-source
cd deps


git clone -b MAINNET https://github.com/Neuralia/Neuralia.NClap
git clone -b MAINNET https://github.com/Neuralia/Neuralia.Open.Nat
git clone -b MAINNET https://github.com/Neuralia/Neuralia.Blockchains.Tools
git clone -b MAINNET https://github.com/Neuralia/Neuralia.BouncyCastle
git clone -b MAINNET https://github.com/Neuralia/Neuralia.Blockchain

cd deps/Neuralia.NClap

rm "Neuralia.NClap.1.0.0.nupkg"
./pack.sh

cp Neuralia.NClap.1.0.0.nupkg ../Neuralia.Blockchains.Tools/local-source/
cp Neuralia.NClap.1.0.0.nupkg ../../local-source/
cp Neuralia.NClap.1.0.0.nupkg ../Neuralia.Blockchain/local-source/
cp Neuralia.NClap.1.0.0.nupkg ../Neuralia.BouncyCastle/local-source/

cd deps/Neuralia.Open.Nat

rm "Neuralia.Open.Nat.1.0.0.nupkg"
./pack.sh

cp Neuralia.Open.Nat.1.0.0.nupkg ../Neuralia.Blockchains.Tools/local-source/
cp Neuralia.Open.Nat.1.0.0.nupkg ../../local-source/
cp Neuralia.Open.Nat.1.0.0.nupkg ../Neuralia.Blockchain/local-source/
cp Neuralia.Open.Nat.1.0.0.nupkg ../Neuralia.BouncyCastle/local-source/


cd deps/Neuralia.Blockchains.Tools

rm "Neuralia.Blockchains.Tools.1.0.0.nupkg"
./pack.sh

cp Neuralia.Blockchains.Tools.1.0.0.nupkg ../Neuralia.Blockchain/local-source/
cp Neuralia.Blockchains.Tools.1.0.0.nupkg ../Neuralia.BouncyCastle/local-source/
cp Neuralia.Blockchains.Tools.1.0.0.nupkg ../../local-source/


cd deps/Neuralia.BouncyCastle

rm "Neuralia.BouncyCastle.1.0.0.nupkg"
./pack.sh

cp Neuralia.BouncyCastle.1.0.0.nupkg Neuralia.Blockchain/local-source/
cp Neuralia.BouncyCastle.1.0.0.nupkg ../local-source/



cd deps/Neuralia.Blockchain

rm "Neuralia.Blockchain.1.0.0.nupkg"
./pack.sh


cp Neuralia.Blockchains.Common.1.0.0.nupkg ../../local-source/
cp Neuralia.Blockchains.Core.1.0.0.nupkg ../../local-source/

