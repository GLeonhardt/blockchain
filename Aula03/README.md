Public Key: 042fa3b72f35805a4e0f0cab7640828916e8c1a668c45222e07405e3094e4e02b08dd4d49830aee229abebc0b45b666feac9f4a4c69a79e9ff46324ac11eec9cea
Private Key: e9cee40902b784c8b374a5941c3d2b6d376f1f053d6684e69b5cb40556bc0c00
Address: mrYcA5j1rUboTBjcgwurQYTxhuZ326L2uc


Depositando na carteira:

depósito feito pelo site `https://testnet-faucet.mempool.co/`

```
TxID: b648e739bc098e01548e3dcf89f10e9b668b58f49546cdfde80d6f3769cc3114
Address: mrYcA5j1rUboTBjcgwurQYTxhuZ326L2uc
Amount: 0.001
```

- Detalhes:

```
https://api.blockcypher.com/v1/btc/test3/txs/b648e739bc098e01548e3dcf89f10e9b668b58f49546cdfde80d6f3769cc3114?limit=50&includeHex=true
```

- Tranferindo:

Ao utlizar como exemplo o código em Ruby dos slides para transferir dados comecei a ter problema em uma classe interna da lib de bitcoin, tentei resolver de diversas formas porém não consegui

Erro:
```
Traceback (most recent call last):
        5: from send.rb:32:in `<main>'
        4: from C:/Ruby27-x64/lib/ruby/gems/2.7.0/gems/bitcoin-ruby-0.0.20/lib/bitcoin/builder.rb:20:in `build_tx'
        3: from send.rb:33:in `block in <main>'
        2: from C:/Ruby27-x64/lib/ruby/gems/2.7.0/gems/bitcoin-ruby-0.0.20/lib/bitcoin/builder.rb:158:in `input'
        1: from send.rb:36:in `block (2 levels) in <main>'
C:/Ruby27-x64/lib/ruby/gems/2.7.0/gems/bitcoin-ruby-0.0.20/lib/bitcoin/builder.rb:403:in `prev_out_index': undefined method `pk_script' for nil:NilClass (NoMethodError)
```
