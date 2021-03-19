import React, { Component } from 'react';

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
    }

    static renderClientTable(cliente) {
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Temp. (F)</th>
                        <th>Summary</th>
                    </tr>
                </thead>
                <tbody>
                    {cliente.map(cliente =>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
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
                <h1>Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
}