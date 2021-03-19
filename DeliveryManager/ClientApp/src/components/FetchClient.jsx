import React, { Component } from 'react';

export class FetchClient extends Component
{
    displayName = FetchClient.name;

    static handlerEdit = function (id) { }

    static handlerDelete(clientId) {
        fetch('Clientes/Delete/' +  clientId )
            .then(response => response.json())
            .then(data => {
                this.setState({ cliente: data, loading: false });
            });
    }
    constructor(props){
        super(props);
        this.state = { cliente: [], loading :true }

        fetch('Clientes')
            .then(response => response.json())
            .then(data => {
                this.setState({ cliente: data, loading: false });
        });
    }
    

    static renderClientTable(cliente) {
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Nome</th>
                        <th>Cpf</th>
                        <th>Telefone</th>
                        <th>ação</th>
                    </tr>
                </thead>
                <tbody>
                    {cliente.map(cliente =>
                        <tr>
                            <td>{cliente.nome}</td>
                            <td>{cliente.cpf}</td>
                            <td>{cliente.telefone}</td>
                            <td>{ console.log(cliente)}</td>
                            <td>
                                <button className="btn btn-success" onClick={id => this.handlerEdit(cliente.id_cliente)}>Editar</button>
                                <button className="btn btn-danger" onClick={id => this.handlerDelete(cliente.id_cliente)}>Deletar</button>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
    render()
    {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchClient.renderClientTable(this.state.cliente);

        return (
            <div>
                <h1>Clientes</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
}