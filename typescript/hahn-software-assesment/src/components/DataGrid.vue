<script setup lang="ts" generic="T">
import { ref, watch } from 'vue'

export interface DataGridColumnOptions {
  filter: boolean
}

export interface DataGridColumn<T> {
  header: string
  value: (row: T, index: number) => string | number | boolean
  options?: DataGridColumnOptions
}

export interface DataGridProps<T> {
  columns: DataGridColumn<T>[]
  rows: T[]
}

const props = defineProps<DataGridProps<T>>()
const rRows = ref<T[]>()
const rColumnsFilterable = ref<DataGridColumn<T>[]>([])
const vmFilter = defineModel<string>()

watch(
  () => props.rows,
  async () => {
    rColumnsFilterable.value = props.columns.filter((c) => c.options?.filter)
    filter(vmFilter.value)
  },
)

watch(
  () => props.columns,
  async () => {
    filter(vmFilter.value)
  },
)

const filter = (text: string = '') => {
  if (text.length > 1) {
    rRows.value = props.rows.filter((x, i) => {
      return rColumnsFilterable.value.some((c) => c.value(x, i).toString().indexOf(text) > -1)
    })
    console.log(rRows.value)
  } else {
    rRows.value = props.rows
  }
}
</script>

<template>
  <table class="table table-striped table-hover w-100">
    <thead>
      <tr>
        <th :colspan="columns.length" v-if="rColumnsFilterable.length">
          Filter :
          <input
            class="form-control form-control-sm"
            v-model="vmFilter"
            v-on:keyup="filter(vmFilter)"
            type="text"
          />
        </th>
      </tr>
      <tr>
        <th class="text-center" v-for="(column, index) in columns" :key="index">
          <small class="font-weight-bold"> {{ column.header.toUpperCase() }}</small>
        </th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="(row, indexRow) in rRows" :key="indexRow">
        <td v-for="(column, indexColumn) in columns" :key="indexColumn">
          <small> {{ column.value(row, indexRow) }}</small>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<style scoped></style>
