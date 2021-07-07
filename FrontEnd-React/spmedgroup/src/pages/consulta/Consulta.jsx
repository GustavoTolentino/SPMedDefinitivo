import axios from "axios";
import { Component } from "react";
import "./Consulta.css";

export default class Consulta extends Component {

  constructor(props) {
    super(props)
    this.state = {
      ListaConsulta: [],
      idPaciente: "",
      idMedico: "",
      idSituacao: 2,
      dataConsulta: "2021-06-30T13:20:44.034Z",
      exames: "Não",
      descricao: ""
    }
  }
  // teste 

  cadastrarConsulta = (event) => {
    event.preventDefault()
    axios.post('http://localhost:5000/api/consultum',
      {
        idPaciente: this.state.idPaciente,
        idMedico: this.state.idMedico,
        idSituacao: this.state.idSituacao,
        dataConsulta: this.state.dataConsulta,
        exames: this.state.exames,
        descricao: this.state.descricao
      })
      .then(this.listarConsulta);
  }
  listarConsulta = () => {
    axios.get('http://localhost:5000/api/consultum')
      .then(resposta => {
        this.setState({ ListaConsulta: resposta.data })
      })
    console.log(this.state.ListaConsulta);
  }
  atualizarState = (campo) => {
    this.setState({ [campo.target.name]: campo.target.value })
  }
  componentDidMount() {
    this.listarConsulta();
  }

  render() {
    return (
      <div>
        <div className="area-main">
          <h1>Cadastro</h1>
          <div className="mainArea">
            <form onSubmit={this.cadastrarConsulta} className="formarea">
              <h2>Nome do Paciente</h2>
              <input type="text" onChange={this.atualizarState} name="idPaciente" value={this.state.idPaciente} className="inputs" />

              <h2>Nome do Medico</h2>
              <input type="text" onChange={this.atualizarState} name="idMedico" value={this.state.idMedico} className="inputs" />

              <h2>Data</h2>
              <input type="date" onChange={this.atualizarState} name="dataConsulta" value={this.state.dataConsulta} className="inputs" />

              <h2>Nome do Exame</h2>
              <input type="text" onChange={this.atualizarState} name="exames" value={this.state.exames} className="inputs" />

              <h2>Descricao</h2>
              <input type="text" onChange={this.atualizarState} name="descricao" value={this.state.descricao} className="inputs" />

              <div className="divButton">
                <button type="submit" className="botao">Enviar</button>
              </div>

            </form>
          </div>
          <div>
            <table>
              <thead>
                <tr>
                  <th>Paciente</th>
                  <th>Medico</th>
                  <th>Descricao</th>
                  <th>Data</th>
                </tr>
              </thead>
              <tbody>
                {this.state.ListaConsulta.map(
                  (consulta) => {
                    return (
                      <tr key={consulta.idConsulta}>
                        <td>{consulta.idPaciente}</td>
                        <td>{consulta.idMedico}</td>
                        <td>{consulta.descricao}</td>
                        <td>{consulta.dataConsulta}</td>
                      </tr>
                    )
                  }
                )}
              </tbody>
            </table>
          </div>
        </div>
      </div>
    );
  }
}