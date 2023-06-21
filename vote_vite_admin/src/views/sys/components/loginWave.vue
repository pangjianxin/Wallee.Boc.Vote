<template>
    <div class="fixed bottom-0 w-full !-z-5 wave-wrapper">
        <svg class="ignore-waves" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink"
            viewBox="0 24 150 28" preserveAspectRatio="none" shape-rendering="auto">
            <defs>
                <path id="gentle-wave" d="M-160 44c30 0 58-18 88-18s 58 18 88 18 58-18 88-18 58 18 88 18 v44h-352z" />
            </defs>
            <g class="parallax">
                <use xlink:href="#gentle-wave" x="48" y="0" :fill="hexToRgba('#5d9dfe', 0.4)" />
                <use xlink:href="#gentle-wave" x="48" y="3" :fill="hexToRgba('#5d9dfe', 0.5)" />
                <use xlink:href="#gentle-wave" x="48" y="5" :fill="hexToRgba('#5d9dfe', 0.6)" />
                <use xlink:href="#gentle-wave" x="48" y="7" :fill="hexToRgba('#5d9dfe', 0.7)" />
            </g>
        </svg>
    </div>
</template>

<script setup lang="ts">
import { hexToRgba } from '/@/utils/app';


</script>

<style scoped lang="scss">
.wave-wrapper {
    position: fixed;
    width: 100%;
    left: 0;
    bottom: 0;

    .parallax {
        >use {
            animation: move-forever 12s cubic-bezier(0.55, 0.5, 0.45, 0.5) infinite;
            animation: move-forever 12s linear infinite;
        }

        >use:nth-child(1) {
            animation-delay: -2s;
            animation-duration: 7s;
        }

        >use:nth-child(2) {
            animation-delay: -3s;
            animation-duration: 10s;
        }

        >use:nth-child(3) {
            animation-delay: -4s;
            animation-duration: 13s;
        }

        >use:nth-child(4) {
            animation-delay: -5s;
            animation-duration: 16s;
        }
    }
}

.ignore-waves {
    position: relative;
    display: block;
    width: 100%;
    height: 50px;
    min-height: 40px;
    max-height: 80px;
}

@keyframes move-forever {
    0% {
        transform: translate3d(-90px, 0, 0);
    }

    100% {
        transform: translate3d(85px, 0, 0);
    }
}
</style>