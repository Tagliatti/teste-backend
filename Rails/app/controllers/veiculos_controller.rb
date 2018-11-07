class VeiculosController < ApplicationController
  before_action :set_veiculo, only: [:show, :edit, :update, :destroy]

  # GET /veiculos
  # GET /veiculos.json
  def index
    @veiculos = Veiculo.all
  end

  def find
    @veiculos = Veiculo.any_of({nome_veiculo: /.*#{params.require(:q)}.*/i}, {descricao: /.*#{params.require(:q)}.*/i})
  end

  # GET /veiculos/1
  # GET /veiculos/1.json
  def show
    @veiculo = Veiculo.find(params.require(:id));
  end

  # POST /veiculos
  # POST /veiculos.json
  def create
    @veiculo = Veiculo.new(veiculo_params)

    respond_to do |format|
      if @veiculo.save
        format.json { render :show, status: :created, location: @veiculo }
      else
        format.json { render json: @veiculo.errors, status: :unprocessable_entity }
      end
    end
  end

  # PATCH/PUT /veiculos/1
  # PATCH/PUT /veiculos/1.json
  def update
    respond_to do |format|
      if @veiculo.update(veiculo_params)
        format.json { render :show, status: :ok, location: @veiculo }
      else
        format.json { render json: @veiculo.errors, status: :unprocessable_entity }
      end
    end
  end

  # DELETE /veiculos/1
  # DELETE /veiculos/1.json
  def destroy
    @veiculo.destroy
    respond_to do |format|
      format.json { head :no_content }
    end
  end

  private
    # Use callbacks to share common setup or constraints between actions.
    def set_veiculo
      @veiculo = Veiculo.find(params[:id])
    end

    # Never trust parameters from the scary internet, only allow the white list through.
    def veiculo_params
      params.require(:veiculo).permit(:nome_veiculo, :marca, :descricao, :vendido)
    end
end
