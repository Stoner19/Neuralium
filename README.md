# Neuralium

The Neuralium crypto token console server node

### Blockchains.Neuralium
The Neuralium blockchain implementation
### Neuralium.Api.Common
API public Interfaces
### Neuralium.Shell
The Neuralium server node components
### Neuralium
The actual command line interface for the Server node.

## Build Instructions

##### First, ensure dotnet core 2.2 SDK is installed

#### The first step is to ensure that the dependencies have been built and copied into the nuget-source folder.

##### the source code to the below dependencies can be found here: [Neuralia Technologies source code]

 - Neuralia.Blockchains.Tools
 - Neuralia.System.Data.HashFunction.xxHash
 - Neuralia.STUN
 - Neuralia.BouncyCastle
 - Neuralia.Blockchains.Core
 - Neuralia.Blockchains.Common

Then, simply invoke the right build file for your needs
>cd targets
> ./linux.sh
this will produce the executable in the folder /build