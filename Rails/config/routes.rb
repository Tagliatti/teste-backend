Rails.application.routes.draw do
  scope '/api' do
    get '/veiculos/find', to: 'veiculos#find'
    resources :veiculos
  end
  # For details on the DSL available within this file, see http://guides.rubyonrails.org/routing.html
end
