require 'rest-client'
require 'json'
require 'bitcoin'

include Bitcoin::Builder
Bitcoin.network = :testnet3

BITCOIN_TRANSACTIONS_PRIVATE_KEY = 'e9cee40902b784c8b374a5941c3d2b6d376f1f053d6684e69b5cb40556bc0c00'
BITCOIN_TRANSACTIONS_PUBLIC_KEY = '042fa3b72f35805a4e0f0cab7640828916e8c1a668c45222e07405e3094e4e02b08dd4d49830aee229abebc0b45b666feac9f4a4c69a79e9ff46324ac11eec9cea'
MY_ADDRESS = 'mrYcA5j1rUboTBjcgwurQYTxhuZ326L2uc'
send_to_me = 5000 # 0.00005 BTC

faucet_address = 'mkHS9ne12qx9pS9VojpwU5xtRd4T7X7ZUt'

send_to = 'mr9xV9aNnfv6a1LhGsvVmFGW63Mn3ZwtJz'
send_value = 25000 # 0.00025 BTC

utxo = '047f52f37f8bb87a3334bae971a6be776fce526641736cae334a69449bdb76cd'
utxo_value = 1000000
utxo_index = 0

bitcoin_fee_per_byte = 46

key = Bitcoin::Key.new(BITCOIN_TRANSACTIONS_PRIVATE_KEY, BITCOIN_TRANSACTIONS_PUBLIC_KEY, opts={compressed: true})

response = RestClient.get("https://sochain.com/api/v2/get_tx/BTCTEST/#{utxo}")
parsed_response = JSON.parse(response)
puts parsed_response
prev_tx = Bitcoin::P::Tx.new(parsed_response['data']['tx_hex'])
puts prev_tx.out

new_tx = build_tx do |t|
  t.input do |i|
    i.prev_out prev_tx
    i.prev_out_index utxo_index
    i.signature_key key
  end

  t.output do |o|
    o.value send_value
    o.script { |s| s.type :address; s.recipient send_to }
  end

  t.output do |o|
    o.value send_to_me
    o.script { |s| s.type :address; s.recipient MY_ADDRESS }
  end

  t.output do |o|
    o.value utxo_value - send_value
    o.script { |s| s.type :address; s.recipient faucet_address }
  end
end

rawtx = new_tx.to_payload.unpack('H*').first
puts rawtx
response = RestClient.post("https://sochain.com/api/v2/send_tx/BTCTEST", { tx_hex: rawtx })
puts JSON.parse(response)