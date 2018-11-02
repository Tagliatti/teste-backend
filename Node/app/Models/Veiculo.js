'use strict'

/** @type {typeof import('@adonisjs/lucid/src/Lucid/Model')} */
const Model = use('Model')

class Veiculo extends Model {
  static search(term) {
    return this.query().whereRaw('nomeVeiculo LIKE :term OR descricao LIKE :term', { term: `%${term}%` }).fetch()
  }
}

module.exports = Veiculo
