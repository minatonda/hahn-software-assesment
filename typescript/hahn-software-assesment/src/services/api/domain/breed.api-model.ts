export interface Breed {
  id: string
  name: string
  description: string
}

export interface BreedAttribute<T> {
  attributeType: number
  value: T
}

export interface BreeedAttributeRange {
  min: number
  max: number
}
