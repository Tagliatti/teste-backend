'use strict'

/** @typedef {import('@adonisjs/framework/src/Request')} Request */
/** @typedef {import('@adonisjs/framework/src/Response')} Response */
/** @typedef {import('@adonisjs/framework/src/View')} View */
const Veiculo = use('App/Models/Veiculo')

/**
 * Resourceful controller for interacting with veiculos
 */
class VeiculoController {
  /**
   * Show a list of all veiculos.
   * GET veiculos
   *
   * @param {object} ctx
   * @param {Request} ctx.request
   * @param {Response} ctx.response
   */
  async index ({ request, response }) {
    return await Veiculo.all()
  }

  /**
   * Show a list of all veiculos by search.
   * GET veiculos/find
   *
   * @param {object} ctx
   * @param {Request} ctx.request
   * @param {Response} ctx.response
   */
  async find ({ request, response }) {
    return await Veiculo.search(request.get().q)
  }

  /**
   * Create/save a new veiculo.
   * POST veiculos
   *
   * @param {object} ctx
   * @param {Request} ctx.request
   * @param {Response} ctx.response
   */
  async store ({ request, response }) {
    const veiculo = await Veiculo.create(this.getParams(request))

    return veiculo
  }

  /**
   * Display a single veiculo.
   * GET veiculos/:id
   *
   * @param {object} ctx
   * @param {Request} ctx.request
   * @param {Response} ctx.response
   * @param {View} ctx.view
   */
  async show ({ params, request, response, view }) {
    return await Veiculo.find(params.id)
  }

  /**
   * Update veiculo details.
   * PUT or PATCH veiculos/:id
   *
   * @param {object} ctx
   * @param {Request} ctx.request
   * @param {Response} ctx.response
   */
  async update ({ params, request, response }) {
    const veiculo = await Veiculo.find(params.id)

    veiculo.merge(this.getParams(request))

    await veiculo.save()
  }

  /**
   * Delete a veiculo with id.
   * DELETE veiculos/:id
   *
   * @param {object} ctx
   * @param {Request} ctx.request
   * @param {Response} ctx.response
   */
  async destroy ({ params, request, response }) {
    const veiculo = await Veiculo.find(params.id)

    await veiculo.delete()
  }

  getParams(request) {
    return request.only(['nomeVeiculo', 'descricao', 'marca', 'vendido'])
  }
}

module.exports = VeiculoController
