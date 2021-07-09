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
        const token =  await AsyncStorage.getItem('userToken')
        const resposta = await (await api.get('/Consultum/Consulta', 
        {
            headers: {
                Authorization: 'Bearer ' + token 
            } 
        }))
        const dados = resposta.data;

        this.setState({ listaConsultas: dados })
    };

    componentDidMount() {
        this.buscarConsultas();
    };

    render() {
        return (
            <View>
                <View style={styles.main}>
                    <FlatList
                        contentContainerStyle={styles.listaMain}
                        data={this.state.listaConsultas}
                        keyExtractor={item => item.idConsulta}
                        renderItem={this.renderItem}
                    />
                </View>
            </View>
        );
    }
    renderItem = ({ item }) => (
        <View contentContainerStyle={styles.mainBodyContent}>
            <View style={styles.flatItemContainer}>
                <Text style={styles.flatItemInfo}>{item.dataConsulta}</Text>
                <Text style={styles.flatItemInfo}>{item.idMedicoNavigation.NomePaciente}</Text>
                <Text style={styles.flatItemInfo}>{item.idPacienteNavigation.nome}</Text>
                <Text style={styles.flatItemInfo}>{item.descricao}</Text>
            </View>
        </View>
    )
}
const styles = StyleSheet.create({
    main: {
        alignItems: 'center',
        justifyContent: 'center'
    },
    flatItemContainer: {
        width: '90%'
    },
    mainBodyContent: {
        paddingTop: 30,
        paddingRight: 50,
        paddingLeft: 50
    },
    flatItemRow: {
        flexDirection: 'row',
        borderBottomWidth: 1,
        borderBottomColor: '#ccc',
        marginTop: 30
    },
      flatItemContainer: {
        flex: 1
    },
      flatItemTitle: {
        fontSize: 16,
        color: '#333',
        fontFamily: 'Open Sans Light'
    },
      flatItemInfo: {
        fontSize: 12,
        color: '#999',
        lineHeight: 20
    },

});