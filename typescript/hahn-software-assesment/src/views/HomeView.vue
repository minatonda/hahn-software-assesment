<script setup lang="ts">
import DataGrid, { type DataGridColumn } from '@/components/DataGrid.vue'
import { getBreedAttributes, getBreeds } from '@/services/api/breed.api-service'
import type {
  Breed,
  BreedAttribute,
  BreeedAttributeRange,
} from '@/services/api/domain/breed.api-model'
import { ref } from 'vue'

const dataBreed = ref<Breed[]>([])
const dataBreedAttributes = ref<BreedAttribute<unknown>[][]>([])

const columns = ref<DataGridColumn<Breed>[]>([
  { header: 'Id', value: (row) => row.id, options: { filter: true } },
  { header: 'Name', value: (row) => row.name, options: { filter: true } },
  { header: 'Description', value: (row) => row.description, options: { filter: true } },
  {
    header: 'LIFE MIN',
    value: (row, index) => {
      const sRow = dataBreedAttributes.value[index][0] as BreedAttribute<BreeedAttributeRange>
      return sRow?.value.min
    },
    options: { filter: true },
  },
  {
    header: 'LIFE MAX',
    value: (row, index) => {
      const sRow = dataBreedAttributes.value[index][0] as BreedAttribute<BreeedAttributeRange>
      return sRow?.value.max
    },
    options: { filter: true },
  },
  {
    header: 'MALE WEIGHT MIN',
    value: (row, index) => {
      const sRow = dataBreedAttributes.value[index][1] as BreedAttribute<BreeedAttributeRange>
      return sRow?.value.min
    },
    options: { filter: true },
  },
  {
    header: 'MALE WEIGHT MAX',
    value: (row, index) => {
      const sRow = dataBreedAttributes.value[index][1] as BreedAttribute<BreeedAttributeRange>
      return sRow?.value.min
    },
    options: { filter: true },
  },
  {
    header: 'FEMALE WEIGHT MIN',
    value: (row, index) => {
      const sRow = dataBreedAttributes.value[index][2] as BreedAttribute<BreeedAttributeRange>
      return sRow?.value.min
    },
  },
  {
    header: 'FEMALE WEIGHT MAX',
    value: (row, index) => {
      const sRow = dataBreedAttributes.value[index][2] as BreedAttribute<BreeedAttributeRange>
      return sRow?.value.min
    },
    options: { filter: true },
  },
  {
    header: 'HYPOALLERGENIC',
    value: (row, index) => {
      const sRow = dataBreedAttributes.value[index][3] as BreedAttribute<boolean>
      return sRow?.value
    },
    options: { filter: true },
  },
])

getBreeds()
  .then((response) => {
    return Promise.all([
      response.data,
      Promise.all(response.data.map((row) => getBreedAttributes(row.id).then((r) => r.data))),
    ])
  })
  .then(([r1, r2]) => {
    dataBreed.value = r1
    dataBreedAttributes.value = r2
  })
</script>

<template>
  <main>
    <div class="card w-100">
      <DataGrid :columns="columns" :rows="dataBreed"></DataGrid>
    </div>
  </main>
</template>
