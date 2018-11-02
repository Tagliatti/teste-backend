'use strict'

/** @type {import('@adonisjs/lucid/src/Schema')} */
const Schema = use('Schema')

class VeiculosSchema extends Schema {
  up () {
    this.create('veiculos', (table) => {
      table.increments()
      table.string('nomeVeiculo')
      table.string('descricao')
      table.string('marca')
      table.boolean('vendido');
      table.timestamps()
    })
  }

  down () {
    this.drop('veiculos')
  }
}

module.exports = VeiculosSchema
