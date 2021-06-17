# NineChronicles Headless (light-node)



## Table of Contents

- [Pre-requisites](#pre-requisites)
- [Run](#run)
- [Preloading](#preloading)
- [Check transaction](#check-transaction)

## Pre-requisites

#### 1. Clone this repository.

```
$ git clone https://github.com/yoonmyung/NineChronicles.Headless.git
```

#### 2. Clone yoonmyung/libplanet repository.

```
$ git clone https://github.com/yoonmyung/libplanet.git
```

#### 3. Open directory you cloned yoonmyung/NineChronicles.Headless.

#### 4. Find directory NineChronicles.Headless/Lib9c/.Libplanet, then overwrite it as directory you cloned yoonmyung/libplanet.

```
$ cp -arpf /path/libplanet /path/NineChronicles.Headless/Lib9c/.Libplanet
```

#### 5. Move into NineChronicles.Headless/NineChronicles.Headless.Executable.

## Run

```
$ dotnet run --project ./NineChronicles.Headless.Executable/ -- --help
Usage: NineChronicles.Headless.Executable [command]
Usage: NineChronicles.Headless.Executable [--no-miner] [--app-protocol-version <String>] [--genesis-block-path <String>] [--host <String>] [--port <Nullable`1>] [--swarm-private-key <String>] [--minimum-difficulty <Int32>] [--miner-private-key <String>] [--store-type <String>] [--store-path <String>] [--ice-server <String>...] [--peer <String>...] [--trusted-app-protocol-version-signer <String>...] [--rpc-server] [--rpc-listen-host <String>] [--rpc-listen-port <Nullable`1>] [--graphql-server] [--graphql-host <String>] [--graphql-port <Nullable`1>] [--graphql-secret-token-path <String>] [--no-cors] [--libplanet-node] [--workers <Int32>] [--confirmations <Int32>] [--max-transactions <Int32>] [--strict-rendering] [--dev] [--dev.block-interval <Int32>] [--dev.reorg-interval <Int32>] [--log-action-renders] [--aws-cognito-identity <String>] [--aws-access-key <String>] [--aws-secret-key <String>] [--aws-region <String>] [--authorized-miner] [--tx-life-time <Int32>] [--message-timeout <Int32>] [--tip-timeout <Int32>] [--demand-buffer <Int32>] [--help] [--version] [--light-node]

NineChronicles.Headless.Executable

Commands:
  validation
  chain
  key

Options:
  --no-miner
  -V, --app-protocol-version <String>                      App protocol version token (Default: )
  -G, --genesis-block-path <String>                         (Default: )
  -H, --host <String>                                       (Default: )
  -P, --port <Nullable`1>                                   (Default: )
  --swarm-private-key <String>                             The private key used for signing messages and to specify your node. If you leave this null, a randomly generated value will be used. (Default: )
  -D, --minimum-difficulty <Int32>                          (Default: 5000000)
  --miner-private-key <String>                             The private key used for mining blocks. Must not be null if you want to turn on mining with libplanet-node. (Default: )
  --store-type <String>                                     (Default: )
  --store-path <String>                                     (Default: )
  -I, --ice-server <String>...                              (Default: )
  --peer <String>...                                        (Default: )
  -T, --trusted-app-protocol-version-signer <String>...    Trustworthy signers who claim new app protocol versions (Default: )
  --rpc-server
  --rpc-listen-host <String>                                (Default: 0.0.0.0)
  --rpc-listen-port <Nullable`1>                            (Default: )
  --graphql-server
  --graphql-host <String>                                   (Default: 0.0.0.0)
  --graphql-port <Nullable`1>                               (Default: )
  --graphql-secret-token-path <String>                     The path to write GraphQL secret token. If you want to protect this headless application, you should use this option and take it into headers. (Default: )
  --no-cors                                                Run without CORS policy.
  --libplanet-node
  --workers <Int32>                                        Number of workers to use in Swarm (Default: 5)
  --confirmations <Int32>                                  The number of required confirmations to recognize a block.  0 by default. (Default: 0)
  --max-transactions <Int32>                               The number of maximum transactions can be included in a single block. Unlimited if the value is less then or equal to 0.  100 by default. (Default: 100)
  --strict-rendering                                       Flag to turn on validating action renderer.
  --dev                                                    Flag to turn on the dev mode.  false by default.
  --dev.block-interval <Int32>                             The time interval between blocks. It's unit is milliseconds. Works only when dev mode is on.  10000 (ms) by default. (Default: 10000)
  --dev.reorg-interval <Int32>                             The size of reorg interval. Works only when dev mode is on.  0 by default. (Default: 0)
  --log-action-renders                                     Log action renders besides block renders.  --rpc-server implies this.
  --aws-cognito-identity <String>                          The Cognito identity for AWS CloudWatch logging. (Default: )
  --aws-access-key <String>                                The access key for AWS CloudWatch logging. (Default: )
  --aws-secret-key <String>                                The secret key for AWS CloudWatch logging. (Default: )
  --aws-region <String>                                    The AWS region for AWS CloudWatch (e.g., us-east-1, ap-northeast-2). (Default: )
  --authorized-miner                                       Run as an authorized miner, which mines only blocks that should be authorized.
  --tx-life-time <Int32>                                   The lifetime of each transaction, which uses minute as its unit.  60 (m) by default. (Default: 60)
  --message-timeout <Int32>                                The grace period for new messages, which uses second as its unit.  60 (s) by default. (Default: 60)
  --tip-timeout <Int32>                                    The grace period for tip update, which uses second as its unit.  60 (s) by default. (Default: 60)
  --demand-buffer <Int32>                                  A number that determines how far behind the demand the tip of the chain will publish `NodeException` to GraphQL subscriptions.  1150 blocks by default. (Default: 1150)
  -h, --help                                               Show help message
  --version                                                Show version
  --light-node                                             Run a node as a light node, which stores only block header (Default: false)
```

## Preloading

#### If you run NineChronicles.Headless as a light node, you can see this log.

```
[19:12:05 DBG] It's Light node.
```

#### After bootstraping, your tip which is the starting point of preloading blocks will decide if it needs to be updated or not.

```
[19:12:15 DBG] The tip before preloading begins: #1710206 0a2df227af7ef4a1bce9723b318320b2b36e8dc5a76d2e04bb25cdfca2b14d4c true
```

"true" in this log means that your tip as a full-node and a light-node are the same or your light-node tip is forward to full-node tip. You don't need update your tip.


```
[19:19:47 DBG] The tip before preloading begins: #1710231 34749a9c87c7f6ecb284f819bb7db33be85f31a0766c6486ce931ae6f7823ac8 false
```

"false" means that your tip as a light-node is behind the tip as a full-node. So you need to update your tip.

#### (WIP) But you'll see this log.
```
[19:19:47 ERR] An unexpected exception occurred during PreloadAsync: The block [34749a9c87c7f6ecb284f819bb7db33be85f31a0766c6486ce931ae6f7823ac8] doesn't exist. (Parameter 'point')
System.ArgumentException: The block [34749a9c87c7f6ecb284f819bb7db33be85f31a0766c6486ce931ae6f7823ac8] doesn't exist. (Parameter 'point')
```

Preloading after changing tip point is under process. I'll fix this as soon as possible.

#### You can check stored block-headers from /path/planetarium/9c-main-partition/blockheader

## Check Transaction

#### If you know the hash value of block, you can check whether this block includes specific transaction or not.

#### While running NineChronicles.Headless, put block hash and transaction Id which you want to check into URL.
![image](https://user-images.githubusercontent.com/40621689/122335710-b08c3000-cf76-11eb-8995-7c2aa73a5116.png)
We use this data.

```
http://[your --host option value]:[your --graphql-port value]/check-tx/
block?txIdString=[ID value of transaction which you want to check]
&blockHashString=[hash value of block which you want to check]
```

#### Result is correct to the data we use.
![gitchecktx](https://user-images.githubusercontent.com/40621689/122335311-07453a00-cf76-11eb-9964-630787d38659.png)

