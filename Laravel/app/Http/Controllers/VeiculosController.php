<?php

namespace App\Http\Controllers;

use App\Veiculo;
use Illuminate\Http\Request;

class VeiculosController extends Controller
{

    public function index()
    {
        return Veiculo::all();
    }

    public function find(Request $request)
    {
        return Veiculo::where('nome_veiculo', 'like', "%{$request->query('q')}%")
            ->orWhere('descricao', 'like', "%{$request->query('q')}%")
            ->get();
    }

    public function store(Request $request)
    {
        return Veiculo::create($request->json()->all());
    }

    public function get($id)
    {
        return Veiculo::find($id);
    }

    public function update(Request $request, $id)
    {
        $veiculo = Veiculo::find($id);
        $json = $request->json()->all();

        $veiculo->nome_veiculo = $json['nome_veiculo'];
        $veiculo->descricao = $json['descricao'];
        $veiculo->marca = $json['marca'];
        $veiculo->vendido = $json['vendido'];
        $veiculo->save();
    }

    public function patch(Request $request, $id)
    {
        $veiculo = Veiculo::find($id);
        $json = $request->json()->all();

        $veiculo->fill($json);

        $veiculo->save();
    }

    public function destroy($id)
    {
        Veiculo::destroy($id);
    }
}
