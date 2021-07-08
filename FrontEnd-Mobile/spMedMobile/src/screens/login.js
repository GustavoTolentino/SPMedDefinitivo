import React, { Component } from 'react';
import { TouchableOpacity, Image, ImageBackgroundBase, StyleSheet, Text, TextInput, Pressable, View } from 'react-native';

import api from '../services/api';

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: ''
        }
    }
<<<<<<< HEAD

    realizarLogin = async () => {
        console.warn( this.state.email + ' ' + this.state.senha );

            const resposta = await api.post('/login', {
                headers: {
                    'Access-Control-Allow-Origin' : '*'
                },
                email : this.state.email,
                senha : this.state.senha
            });
=======
    realizarLogin = async () => {
        try {
            const resposta = await api.post('/Login', {
                email: this.state.email,
                senha: this.state.senha
            })

            console.warn(this.state.email)
            console.warn(this.state.senha)
>>>>>>> 993f8aa27c76b5335efa91c47ba60e4dd233e005

            const token = resposta.data.token;
            console.warn(token)
            
            await AsyncStorage.setItem('userToken', token);
            

            this.props.navigation.navigate('Consulta');

<<<<<<< HEAD
       
=======
        } catch (erro) {
            console.warn(erro)
        }
>>>>>>> 993f8aa27c76b5335efa91c47ba60e4dd233e005


    };
    render() {
        return (
            <View>
                <View style={styles.divMain}>
                    <View style={styles.contentArea}>
                        <Image style={styles.logo} source={'../../assets/logo.png'} />
                        <Text style={styles.logoText}>SP Medical Group</Text>

                        <View style={styles.inputArea}>
                            <Text style={styles.inputText}>E-mail</Text>
<<<<<<< HEAD
                            <TextInput style={styles.input} placeholder="E-mail" keyboardType="email-address" onChangeText={email => this.setState({email})} />
=======
                            <TextInput style={styles.input} placeholder="E-mail" keyboardType="email-address" onChange={email => this.setState({ email })} />
>>>>>>> 993f8aa27c76b5335efa91c47ba60e4dd233e005
                        </View>

                        <View style={styles.inputArea}>
                            <Text style={styles.inputText}>Senha</Text>
<<<<<<< HEAD
                            <TextInput style={styles.input} placeholder="Password" secureTextEntry={true} onChangeText={senha => this.setState({senha})} />
=======
                            <TextInput style={styles.input} placeholder="Password" secureTextEntry={true} onChange={senha => this.setState({ senha })} />
>>>>>>> 993f8aa27c76b5335efa91c47ba60e4dd233e005
                        </View>

                        <Pressable
                            style={styles.btnLogin}
                            onPress={this.realizarLogin}>
                            <Text style={styles.btnLoginText}>Login</Text>
                        </Pressable>

                    </View>
                </View>
            </View>
        )
    }
}

const styles = StyleSheet.create({
    overlay: {
        ...StyleSheet.absoluteFillObject,
        backgroundColor: '#EBF5FB'
    },
    divMain: {
        backgroundColor: '#EBF5FB',
        justifyContent: 'center',
        alignItems: 'center',
    },
    contentArea: {
        backgroundColor: '#ffffff',
        border: 'solid 1px #83BEDF',
        borderRadius: "10px"
    },
    logoText: {
        color: '#83BEDF',
        fontSize: '16px',
        fontFamily: 'Prompt',
    },
    inputArea: {
        justifyContent: 'center',
        alignItems: 'center'
    },
    inputText: {
        color: '#415E6F',
        fontSize: '10px',
        fontFamily: 'Prompt'
    },
    input: {
        border: 'solid 1px #83BEDF',
        borderRadius: '10px',
        width: '80px'
    },
    btnLogin: {
        alignItems: 'center',
        justifyContent: 'center',
        height: 35,
        width: 210,
        backgroundColor: '#81DF99',
        borderWidth: 1,
        borderRadius: 4,
        marginTop: 20,
    },
    btnLoginText: {
        color: '#415E6F',
        fontSize: '10px',
        fontFamily: 'Prompt'
    }
})