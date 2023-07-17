import { Inter } from 'next/font/google'
import StyledComponentsRegistry from "@/utils/libs/registry"
import { GlobalStyles } from "@/@styles/globals"
import { AuthController } from '@/components/Auth'
import { Providers } from "@/components/Providers"

const inter = Inter({ subsets: ['latin'] })

interface IRootLayout {
  children: React.ReactNode
}

export const metadata = {
  title: {
    default: 'iMab',
    template: '%s | iMab',
  },
}

export default function RootLayout({ children }: IRootLayout) {

  return (
    <html lang="en">
      <body className={inter.className}>
        <StyledComponentsRegistry>
          <Providers>
            <AuthController />
            <GlobalStyles/>
            {children}
          </Providers>
        </StyledComponentsRegistry>
      </body>
    </html>
  )
}
