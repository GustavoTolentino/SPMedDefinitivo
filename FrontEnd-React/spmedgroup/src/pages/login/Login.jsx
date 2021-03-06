import "./Login.css"
import logo from "../../img/logo_spmedgroup_v1.png"
import { useState } from "react";
import axios from 'axios';
import { useHistory } from "react-router-dom";
import { render } from "@testing-library/react";
// const [ listaTiposUsuarios, setListaTiposUsuarios ] = useState( [] );
// const [ titulo, setTitulo ] = useState( '' );
// const [ isLoading, setIsLoading ] = useState( false );

function Login() {

  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");
  // const [isLoading, setIsLoading] = useState(false);
  const history = useHistory();

  async function btnEntrar_Click() {
    // setIsLoading(true);
    try {
      const response = await axios.post('https://localhost:5000/api/login',
        {
          email: email,
          senha: senha
        }).then(response => {
          localStorage.setItem("token", response.data.token),
            this.props.history.push("/Consulta")
        }).catch(error => {
          console.log(error);
        });
    }

  atualizarState = (campo) => {
      // this.setState({ [campo.target.name] : campo.target.value})
      this.setState(prevState => ({
        Usuario: {
          ...prevState.Usuario,
          [campo.target.name]: campo.target.value
        }
      }))
    }
    render() {
      return (
        <div>
          <div className="area-main">
            <div className="area-conteudo">
              <img src={logo} className="logo" />
              <h3>SP Medical Group</h3>

              <div className="area-inputs">

                <form onSubmit={btnEntrar_Click}>

                  <div className="input-mail">
                    <p>E-mail</p>
                    <input type="text" value={email} onChange={(event) => setEmail(event.target.value)} className="email-input" />
                  </div>

                  <div className="input-senha">
                    <p>Senha</p>
                    <input type="text" value={senha} onChange={(event) => setSenha(event.target.value)} className="senha-input" />
                  </div>

                  <button className="btnEntrar" type="submit">Entrar</button>
                </form>
              </div>
            </div>
          </div>
        </div>
      )
    }
  }