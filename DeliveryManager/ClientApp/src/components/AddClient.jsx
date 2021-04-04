import React, { Component } from 'react';
import { cpfMask, telephoneMask } from '../shared/mask';

export class Client
{
    constructor()
    {
        this.cpf = "";
        this.nome = "";
        this.telefone = "";
        this.id_cliente = 0;
    }
}

export class AddClient extends Component
{
    displayName = AddClient.name;

    constructor(props)
    {
        super(props);     
        this.state = { title: "", loading: true, clientData: new Client };

        var clientId = this.props.match.params["clientId"];
        if (clientId) {
            fetch('Clientes/Details/' + clientId)
                .then((response) => response.json())
                .then((data) => {
                    this.setState({ title: "Edit", loading: false, clientData: data });

                })
        } else
        {
            this.state = { title: "Create", loading: false, clientData: new Client };
        }

        this.handleSave = this.handleSave.bind(this);
        this.handleCancel = this.handleCancel.bind(this);

    }

    handlerChangeName(event) {
        var client = this.state.clientData;
        client.nome = event.target.value;

        this.setState({ clientData: client });
    }
    handlerChangeCpf(event) {
        var client = this.state.clientData;
        client.cpf = cpfMask(event.target.value);

        this.setState({ clientData: client });
    }
    handlerChangeTelephone(event) {
        var client = this.state.clientData;
        client.telefone = telephoneMask(event.target.value);

        this.setState({ clientData: client });
    }

    handleSave(event) {
 
        event.preventDefault();
        const data = new FormData(event.target);

        var clientId = this.state.clientData.id_cliente;

        // PUT request for Edit employee.  
        if (clientId) {
            data.set("Id_cliente", clientId)
            fetch('Clientes/Edit/' + clientId, {
                method: 'PUT',
                body: data,

            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/fetchclient");
                })
        }

        // POST request for Add employee.  
        else {
            fetch('Clientes/Create', {
                method: 'POST',
                body: data,

            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/fetchclient");
            })
        }              

    }

    handleCancel(event) {
        event.preventDefault();
        this.props.history.push("/fetchclient");   
    }  


    renderCreateForm()
    {
        return (
            <form onSubmit={ this.handleSave}>
                < div className="form-group row" >
                    <div className="col-md-10" >
                        <label className=" control-label text-primary h4" htmlFor="Nome">Informações Pessoais</label>
                        <input type="hidden" name="ClienteId" />
                    </div>
                    <div class="col-md-5">
                        <label className=" control-label" htmlFor="Nome">Nome Completo</label>
                        <div className="">
                            <input id="teste"
                                className="form-control"
                                type="text"
                                name="Nome"
                                value={this.state.clientData.nome}
                                onChange={this.handlerChangeName.bind(this)}/>
                        </div>
                    </div>
                    <div class="col-md-5">
                        <label className=" control-label" htmlFor="Cpf">Cpf</label>
                        <div className="">
                            <input className="form-control"
                                type="text"
                                name="Cpf" value={this.state.clientData.cpf}
                                onChange={this.handlerChangeCpf.bind(this)} />
                        </div>
                    </div>
                </div >
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="Telefone" >Telefone</label>
                    <div className="col-md-4">
                        <input className="form-control"
                            type="text" name="Telefone"
                            value={this.state.clientData.telefone}
                            onChange={this.handlerChangeTelephone.bind(this)} />
                    </div>
                </div>

                < div className="form-group row" >
                    <div className="col-md-12" >
                        <label className=" control-label text-primary h4" htmlFor="Nome">Endereço</label>
                        <input type="hidden" name="ClienteId" />
                    </div>
                    <div class="col-md-2">
                        <label className=" control-label" htmlFor="Nome">CEP</label>
                        <div className="">
                            <input id="teste"
                                className="form-control"
                                type="text"
                                name="Nome"
                                value={this.state.clientData.nome}
                                onChange={this.handlerChangeName.bind(this)} />
                        </div>
                    </div>
                    <div class="col-md-5">
                        <label className=" control-label" htmlFor="Cpf">Logradouro</label>
                        <div className="">
                            <input className="form-control"
                                type="text"
                                name="Cpf" value={this.state.clientData.cpf}
                                onChange={this.handlerChangeCpf.bind(this)} />
                        </div>
                    </div>
                    <div class="col-md-3    ">
                        <label className=" control-label" htmlFor="Cpf">Número</label>
                        <div className="">
                            <input className="form-control"
                                type="text"
                                name="Cpf" value={this.state.clientData.cpf}
                                onChange={this.handlerChangeCpf.bind(this)} />
                        </div>
                    </div>
                </div >
                < div className="form-group row" >

                    <div class="col-md-4">
                        <label className=" control-label" htmlFor="Nome">Bairro</label>
                        <div className="">
                            <input id="teste"
                                className="form-control"
                                type="text"
                                name="Nome"
                                value={this.state.clientData.nome}
                                onChange={this.handlerChangeName.bind(this)} />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <label className=" control-label" htmlFor="Cpf">Cidade</label>
                        <div className="">
                            <input className="form-control"
                                type="text"
                                name="Cpf" value={this.state.clientData.cpf}
                                onChange={this.handlerChangeCpf.bind(this)} />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <label className=" control-label" htmlFor="Cpf">Estado</label>
                        <div className="">
                            <input className="form-control"
                                type="text"
                                name="Cpf" value={this.state.clientData.cpf}
                                onChange={this.handlerChangeCpf.bind(this)} />
                        </div>
                    </div>
                </div >
                < div className="form-group row" >

                    <div class="col-md-4">
                        <label className=" control-label" htmlFor="Nome">Complemento</label>
                        <div className="">
                            <input id="teste"
                                className="form-control"
                                type="text"
                                name="Nome"
                                value={this.state.clientData.nome}
                                onChange={this.handlerChangeName.bind(this)} />
                        </div>
                    </div>
                   
                </div >
                <div className="form-group">
                    <button type="submit" className="btn btn-default" >Save</button>&nbsp;    
                    <button className="btn btn-default" onClick={this.handleCancel}>Cancel</button>
                </div >
            </form >
        )  
    }
    render()
    {
        let contents = this.state.loading
                ? <p><em>Loading...</em></p>
                : this.renderCreateForm();
        return (

            <div>
                <h3>Clientes</h3>
                <hr />
                {contents}
            </div>  
        );
    }
}