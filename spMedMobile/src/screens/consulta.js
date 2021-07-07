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
                <View>
                    <Text>Listagem</Text>
                    <FlatList 
                        contentContainerStyle={styles.listaMain}
                        data={this.state.listaConsultas}
                        keyExtractor={item => item.id}
                        />
                </View>
            </View>
        )
    }
    renderItem = ({item}) => (
        <View contentContainerStyle={styles.mainBodyContent}>
            <View style={styles.flatItemContainer}>
                <Text style={styles.flatItemTitle}>{item.idConsultaNavigation.consulta1}</Text>
                <Text style={styles.flatItemInfo}>{item.descricao1}</Text>
            </View>
        </View>
    )
}
const styles = StyleSheet.create({
    main: {
        alignItems: 'center',
        justifyContent: 'center'
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