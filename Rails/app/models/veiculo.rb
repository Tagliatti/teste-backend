class Veiculo
  include Mongoid::Document
  include Mongoid::Timestamps
  
  field :nome_veiculo, type: String
  field :marca, type: String
  field :descricao, type: String
  field :vendido, type: Boolean
end
