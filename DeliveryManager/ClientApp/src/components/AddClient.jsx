import React, { Component } from 'react';

export class Client
{
    constructor()
    {
        this.cpf = "";
        this.nome = "";
        this.telefone = "";
    }
}

export class AddClient extends Component
{
    displayName = AddClient.name;

    constructor(props)
    {
        super(props);     
        this.state = { title: "Create", loading: false, clientData: new Client };

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
        client.cpf = event.target.value;

        this.setState({ clientData: client });
    }
    handlerChangeTelephone(event) {
        var client = this.state.clientData;
        client.telefone = event.target.value;

        this.setState({ clientData: client });
    }

    handleSave(event) {
        event.preventDefault();
        let formData = new FormData();
        formData.append('nome', '448146');
        formData.append('telefone', '466464');
        formData.append('cpf', '161616');

        const options = {
            method: 'POST',
            body: formData

        }

        //fetch('/Clientes/Create', options)
        //    .then(response => response.json())
        //    .then(responseJson => {
        //        console.log(responseJson);
        //        this.props.history.push("/fetchclient");
        //    }).catch(function (err) {
        //        console.error(err);
        //    });

        const response = fetch('/Clientes/Create', options)
        console.log(response);

        

    }

    handleCancel(event) {
        event.preventDefault();
        this.props.history.push("/fetchclient");   
    }  


    renderCreateForm()
    {
        return (
            <form onSubmit={ this.handleSave}>
                <div className="form-group row" >
                    <input type="hidden" name="ClienteId"  />
                </div>
                < div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Nome">Nome Completo</label>
                    <div className="col-md-4">
                        <input id="teste"
                            className="form-control"
                            type="text"
                            name="Nome"
                            value={this.state.clientData.nome}
                            onChange={this.handlerChangeName.bind(this)}/>
                    </div>
                </div >
                < div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Cpf">Cpf</label>
                    <div className="col-md-4">
                        <input className="form-control"
                            type="text"
                            name="Cpf" value={this.state.clientData.cpf}
                            onChange={this.handlerChangeCpf.bind(this)} />
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

                <div className="form-group">
                    <button type="submit" className="btn btn-default" >Save</button>
                    <button  className="btn" onClick={this.handleCancel}>Cancel</button>
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
                <h1></h1>
                    <h3>Clientes</h3>
                <hr />
                {contents}
            </div>  
        );
    }
}