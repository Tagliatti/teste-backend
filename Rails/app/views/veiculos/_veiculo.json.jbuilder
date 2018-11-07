json.extract! veiculo, :id, :nome_veiculo, :marca, :descricao, :vendido, :created_at, :updated_at
json.url veiculo_url(veiculo, format: :json)
