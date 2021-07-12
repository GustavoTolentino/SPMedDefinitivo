import React, { Component } from 'react';
import { TouchableOpacity, Image, ImageBackgroundBase, StyleSheet, Text, TextInput, Pressable, View } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: ''
        }
    }
    realizarLogin = async () => {
        try {
            const resposta = await api.post('/Login', {
                email: this.state.email,
                senha: this.state.senha
            })

            console.warn(this.state.email)
            console.warn(this.state.senha)

            const token = resposta.data.token;
            console.warn(token)

            await AsyncStorage.setItem('userToken', token);


            this.props.navigation.navigate('Consulta');

        } catch (erro) {
            console.warn(erro)
        }
    };
    render() {
        return (
            <View>
                <View style={styles.divMain}>
                    <View style={styles.contentArea}>
                        <Image style={styles.logo} source={'../img/logo_spmedgroup_v1.png'} />
                        <Text style={styles.logoText}>SP Medical Group</Text>

                        <View style={styles.inputAreaemail}>
                            <Text style={styles.inputText}>E-mail</Text>
                            <TextInput style={styles.input} placeholder="E-mail" keyboardType="email-address" onChangeText={email => this.setState({ email })} />
                        </View>

                        <View style={styles.inputArea}>
                            <Text style={styles.inputText}>Senha</Text>
                            <TextInput style={styles.input} placeholder="Password" secureTextEntry={true} onChangeText={senha => this.setState({ senha })} />
                        </View>

                        <Pressable
                            style={styles.btnLogin}
                            onPress={this.realizarLogin}
                            >
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
        height: '100vh',
        width: '100vw'
    },
    contentArea: {
        marginTop:'-30%' ,
        backgroundColor: '#ffffff',
        width:'70%',
        height:'65%' ,
        border: 'solid 1px #83BEDF',
        borderRadius: "10px",
        alignItems: 'center',
        justifyContent: 'center',
        flexDirection:'column'
        
    },
    logoText: {
        marginTop: '-70%',
        color: '#83BEDF',
        fontSize: '28px',
        fontFamily: 'Prompt',
        position: 'absolute'
    },
    inputAreaemail:{
        justifyContent: 'center',
        alignItems: 'center',
        marginTop:'80px'
    },
    inputArea: {
        justifyContent: 'center',
        alignItems: 'center',
        marginTop: '20px'
    },
    inputText: {
        color: '#415E6F',
        fontSize: '17px',
        fontFamily: 'Prompt'
    },
    input: {
        textAlign: 'center',
        border: 'solid 1px #83BEDF',
        borderRadius: '10px',
        width: '150px'
    },
    btnLogin: {
        alignItems: 'center',
        justifyContent: 'center',
        height: 35,
        width: 210,
        backgroundColor: '#81DF99',
        borderWidth: 1,
        borderRadius: 4,
        marginTop: 30,
        marginBottom: -20,
        border: 'solid 0.8px #c4c4c4 '

    },
    btnLoginText: {
        color: '#415E6F',
        fontSize: '16px',
        fontWeight: 'bold',
        fontFamily: 'Prompt',
    }
})