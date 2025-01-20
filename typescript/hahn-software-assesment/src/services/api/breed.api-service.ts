import axios from 'axios'
import type { Breed, BreedAttribute } from './domain/breed.api-model'

export function getBreeds() {
  return axios.get<Breed[]>('http://localhost:5094/api/breed')
}

export function getBreedAttributes(id: string) {
  return axios.get<BreedAttribute<unknown>[]>(`http://localhost:5094/api/breed/${id}/attributes`)
}
