import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class FetchClient extends Component
{
    displayName = FetchClient.name;


    constructor(props){
        super(props);
        this.state = { cliente: [], loading :true }

        fetch('Clientes')
            .then(response => response.json())
            .then(data => {
                this.setState({ cliente: data, loading: false });
            });
        this.handlerDelete = this.handlerDelete.bind(this);
        this.handlerEdit = this.handlerEdit.bind(this);
    }

     handlerDelete(clientId) {
        fetch('Clientes/Delete/' +  clientId )
            .then(response => response.json())
            .then(data => {
                
            });
     }

     handlerEdit() { }

    static renderClientTable(cliente) {
        return (
             
            <table className='table'>
                <thead>
                    <tr>
                        <th>Nome</th>
                        <th>Cpf</th>
                        <th>Telefone</th>
                    </tr>
                </thead>
                <tbody>
                    {cliente.map(cliente =>
                        <tr>
                            <td>{cliente.nome}</td>
                            <td>{cliente.cpf}</td>
                            <td>{cliente.telefone}</td>
                            <td>
                                <button className="btn btn-success" onClick={id => this.handlerEdit(cliente.id_cliente)}>Editar</button>&nbsp;                                
                                <button className="btn btn-danger " onClick={id => this.handlerDelete(cliente.id_cliente)}>Deletar</button>
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
                <p>
                    <Link to={"/addclient"}>
                        <button className="btn btn-primary" >Criar Usuário</button>
                    </Link> 
                </p>
                {contents}
            </div>
        );
    }
}