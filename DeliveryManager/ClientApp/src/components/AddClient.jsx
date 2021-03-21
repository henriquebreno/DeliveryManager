import React, { Component } from 'react';

export class AddClient extends Component
{
    displayName = AddClient.name;

    constructor(props)
    {
        super(props);
        this.state = { cliente: [], loading: false }

        this.handleSave = this.handleSave.bind(this);
        this.handleCancel = this.handleCancel.bind(this);
    }

    handleSave() { }

    handleCancel() { }  

    static renderCreateForm()
    {
        return (
            <form onClick={ handleSave()}>
                <div className="form-group row" >
                    <input type="hidden" name="ClienteId"  />
                </div>
                < div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Name">Nome</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="name"  required />
                    </div>
                </div >
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="Gender">Gender</label>
                    <div className="col-md-4">
                        <select className="form-control" data-val="true" name="gender"  required>
                            <option value="">-- Select Gender --</option>
                            <option value="Male">Male</option>
                            <option value="Female">Female</option>
                        </select>
                    </div>
                </div >
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="Department" >Department</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="Department"  required />
                    </div>
                </div>
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="City">City</label>
                    <div className="col-md-4">
                        <select className="form-control" data-val="true" name="City" required>
                            <option value="">-- Select City --</option>
                            
                        </select>
                    </div>
                </div >
                <div className="form-group">
                    <button type="submit" className="btn btn-default">Save</button>
                    <button className="btn" >Cancel</button>
                </div >
            </form >
        )  
    }
    render()
    {
        let contents = this.state.loading
                ? <p><em>Loading...</em></p>
                : AddClient.renderCreateForm();
        return (

            <div>
                <h1></h1>
                    <h3>Employee</h3>
                <hr />
                {contents}
            </div>  
        );
    }
}