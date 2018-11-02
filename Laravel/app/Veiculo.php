<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Veiculo extends Model
{
    protected $fillable = ['nome_veiculo', 'descricao', 'marca', 'vendido'];
}
