import React, { Component } from 'react';
import { ImageBackgroundBase, StyleSheet, Text, TextInput, Pressable, View, FlatList } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api'

export default class Consulta extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaConsultas: []
        }
    }

    buscarConsultas = async () => {
        const resposta = await api.get('/Consultum');
        const dados = resposta.data;

        this.setState({ listaConsultas : dados })
    };

    componentDidMount(){
        this.buscarConsultas();
    };

    render(){
        return(
            <View>

            </View>
        )
    }
    renderItem = ({item}) => (
        <View>

        </View>
    )
}
const styles = StyleSheet.create({
    main: {
        alignItems: 'center',
        justifyContent: 'center'
    }

});