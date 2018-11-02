<?php

use Illuminate\Http\Request;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/

Route::get('/veiculos', 'VeiculosController@index');
Route::get('/veiculos/find', 'VeiculosController@find');
Route::post('/veiculos', 'VeiculosController@store');
Route::get('/veiculos/{id}', 'VeiculosController@get');
Route::put('/veiculos/{id}', 'VeiculosController@update');
Route::patch('/veiculos/{id}', 'VeiculosController@patch');
Route::delete('/veiculos/{id}', 'VeiculosController@destroy');
